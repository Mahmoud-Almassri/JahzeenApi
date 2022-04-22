using JahzeenApi.Domain.Models;
using Domain;
using Excepticon.AspNetCore;
using Excepticon.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Service.Interfaces;
using Service.Services;
using Service.UnitOfWork;
using STS_Budget.Middleware;
using System;

namespace JahzeenApi
{

    public class Startup
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization();
            services.AddControllers().AddNewtonsoftJson(options =>
                       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddCors();
            services.AddDbContext<JahzeenContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
            });
            services.AddExcepticon();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JahzeenApi Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                             {
                               Reference = new OpenApiReference
                                 {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                 }
                              },
                         new string[] { }
                     }
                 });
            });
            services.AddAuthentication()
                      .AddGoogle("google", opt =>
                      {
                          var googleAuth = Configuration.GetSection("Authentication:Google");
                          opt.ClientId = googleAuth["ClientId"];
                          opt.ClientSecret = googleAuth["ClientSecret"];
                          opt.SignInScheme = IdentityConstants.ExternalScheme;
                      });
            services.AddIdentity<ApplicationUser, Roles>()
                .AddEntityFrameworkStores<JahzeenContext>()
                .AddDefaultTokenProviders()
                                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("SMSProvider")
                .AddSignInManager();
            services.AddAuthorization(options =>
                options.AddPolicy("TwoFactorEnabled",
                      x => x.RequireClaim("amr", "mfa")));
            services.Configure<Domain.DTO.SMSoptions>(Configuration);
            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            });

            services.AddAuthorization(config =>
            {
                config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
            });
            services.AddTokenAuthentication(Configuration);

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHttpContextAccessor();
            services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            services.AddScoped<IServiceUnitOfWork, ServiceUnitOfWork>();


        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }


            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseCors(
             options => options.WithOrigins("*").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
         );
            app.UseAuthentication();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseExcepticon();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Safe Deliver Api");
            });
        }
    }
    public class Policies
    {
        public const string Seller = "Seller";
        public const string Admin = "Admin";
        public const string Driver = "Driver";
        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Admin).Build();
        }
        public static AuthorizationPolicy SellerPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Seller).Build();
        }
        public static AuthorizationPolicy DriverPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Driver).Build();
        }
    }
}
