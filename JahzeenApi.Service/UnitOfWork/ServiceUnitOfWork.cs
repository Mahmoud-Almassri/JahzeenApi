using AutoMapper;
using JahzeenApi.Domain.Models;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repository.UnitOfWork;
using Service.Interfaces;
using Service.Interfaces.Common;
using Service.Services;
using Service.Services.Common;
using System;
using JahzeenApi.Service.Interfaces;
using JahzeenApi.Service.Services;

namespace Service.UnitOfWork
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly LoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public Lazy<IApplicationExceptionsService> ApplicationExceptions { get; set; }
        public Lazy<IEmployeeAuthService> EmployeeAuth { get; set; }
        public Lazy<IEmployerAuthService> EmployerAuth { get; set; }
        public Lazy<IUserService> User { get; set; }
        public Lazy<IWebUserService> WebUser { get; set; }
        public Lazy<IAppSettingsService> AppSettings { get; set; }
        public Lazy<IContactUsService> ContactUs { get; set; }
        public Lazy<ISkillService> Skill { get; set; }
        public Lazy<IExperienceService> Experience { get; set; }
        public Lazy<IUserSkillService> UserSkill { get; set; }
        public Lazy<IEmployeeService> Employee { get; set; }
        public Lazy<IEmployerService> Employer { get; set; }
        public Lazy<IApprovalService> Approval { get; set; }
        public Lazy<IEmployeeAttachmentsService> EmployeeAttachments { get; set; }
        public Lazy<IAdminAuthService> AdminAuth { get; set; }

        public ServiceUnitOfWork(JahzeenContext context,
                                UserManager<ApplicationUser> userManager,
                                IHttpContextAccessor httpContextAccessor,
                                SignInManager<ApplicationUser> signInManager,
                                IWebHostEnvironment webHostEnvironment,
                                IConfiguration configuration,
                                IMapper mapper)
        {
            _repositoryUnitOfWork = new RepositoryUnitOfWork(context, mapper);
            _loggedInUserService = new LoggedInUserService(httpContextAccessor);
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            ApplicationExceptions = new Lazy<IApplicationExceptionsService>(() => new ApplicationExceptionsService(_repositoryUnitOfWork));
            EmployeeAuth = new Lazy<IEmployeeAuthService>(() => new EmployeeAuthService(configuration, userManager, _repositoryUnitOfWork, signInManager, _loggedInUserService));
            EmployerAuth = new Lazy<IEmployerAuthService>(() => new EmployerAuthService(configuration, userManager, _repositoryUnitOfWork, signInManager, _loggedInUserService));
            User = new Lazy<IUserService>(() => new UserService(userManager, _repositoryUnitOfWork, _loggedInUserService, _mapper));
            WebUser = new Lazy<IWebUserService>(() => new WebUserService(userManager, _repositoryUnitOfWork, _loggedInUserService, _mapper));
            ContactUs = new Lazy<IContactUsService>(() => new ContactUsService(_repositoryUnitOfWork));
            AppSettings = new Lazy<IAppSettingsService>(() => new AppSettingsService(_repositoryUnitOfWork, _mapper));
            Skill = new Lazy<ISkillService>(() => new SkillService(_repositoryUnitOfWork, _mapper));
            Experience = new Lazy<IExperienceService>(() => new ExperienceService(_repositoryUnitOfWork, _mapper));
            UserSkill = new Lazy<IUserSkillService>(() => new UserSkillService(_repositoryUnitOfWork, _mapper));
            Employee = new Lazy<IEmployeeService>(() => new EmployeeService(configuration, userManager,_repositoryUnitOfWork, _loggedInUserService ,_webHostEnvironment,_mapper));
            Employer = new Lazy<IEmployerService>(() => new EmployerService(configuration, userManager, _repositoryUnitOfWork, _loggedInUserService,_mapper, _webHostEnvironment));
            Approval = new Lazy<IApprovalService>(() => new ApprovalService( _repositoryUnitOfWork, userManager, mapper));
            EmployeeAttachments = new Lazy<IEmployeeAttachmentsService>(() => new EmployeeAttachmentsService( _repositoryUnitOfWork,_loggedInUserService,_mapper));
            AdminAuth = new Lazy<IAdminAuthService>(() => new AdminAuthService(userManager, signInManager));
        }

        public void Dispose() { }
    }
}
