using Domains.DTO;
using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.Models;
using JahzeenApi.Domain.Models.Common;
using JahzeenApi.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.UnitOfWork;
using Service.Services;
using Service.Services.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Service.Services
{
    public class AdminAuthService : IAdminAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        AppConfiguration _appConfiguration = new AppConfiguration();
        private EmailSender emailSender;
        public AdminAuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<LoginResponseDTO> Login(AdminLoginRequestDTO model)
        {
            ApplicationUser user = _userManager.Users.FirstOrDefault(x => x.UserName == model.Username || x.Email == model.Username || x.PhoneNumber == model.Username);

            if (user != null)
            {
                SignInResult oSignInResult = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

                if (oSignInResult.Succeeded)
                {
                    IList<string> roles = await _userManager.GetRolesAsync(user);
                    IList<Claim> claims = await BuildClaims(user);

                    LoginResponseDTO oLoginResponseDTO = new LoginResponseDTO()
                    {
                        AccessToken = WriteToken(claims),
                        UserId = user.Id.ToString(),
                        UserName = user.UserName,
                        FullName = user.FullName,
                        PhoneNumber = user.PhoneNumber,
                        Email = user.Email,
                        Roles = roles
                    };

                    return oLoginResponseDTO;
                }
                else
                {
                    throw new ValidationException("Password Is Wrong");
                }
            }
            else
            {
                throw new ValidationException("UserName is Wrong");
            }
        }
        public async Task<bool> ForgetPassword(EmployerForgetPasswordDTO forgetPassword)
        {
            if (!string.IsNullOrEmpty(forgetPassword.EmailAddress) && _userManager.Users.Any(x => x.Email.Equals(forgetPassword.EmailAddress)))
            {
                var user = await _userManager.FindByEmailAsync(forgetPassword.EmailAddress);
                if (user != null && await _userManager.IsEmailConfirmedAsync(user))
                {
                    string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    if (!string.IsNullOrEmpty(token))
                    {
                        emailSender.sendResetPasswordEmail(user, token, forgetPassword.Language);
                    }

                    return true;
                }

                throw new ValidationException("There is a problem with this user");
            }
           
            else
            {
                throw new ValidationException("Email Not Correct");

            }
        }
        public async Task<bool> ResetPassword(EmployerResetPasswordDTO restPassword)
        {
            var user = await _userManager.FindByEmailAsync(restPassword.EmailAddress);
            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, restPassword.Token, restPassword.Password);
                if (result.Succeeded)
                {
                    return true;
                }
                throw new ValidationException("problem");

            }
            throw new ValidationException("User Not Exisits");
        }
        public async Task<AdminAuthDashboardResponseDTO> GetDashboardData()
        {
            IList<ApplicationUser> employees = await _userManager.GetUsersInRoleAsync("Employee");
            IList<ApplicationUser> employers = await _userManager.GetUsersInRoleAsync("Employer");

            List<DashboardDTO> dashboards = new List<DashboardDTO>
            {
                new DashboardDTO { Name = "Total employees", Value = employees.Count().ToString(),Url="/users-management/list-users",Icon="person" },
                new DashboardDTO { Name = "Total employers", Value = employers.Count().ToString(),Url="/users-management/list-users",Icon="person" },
            };
            DateTime thisWeekFirstDate = FirstDateOfWeek(DateTime.Now.Year, GetIso8601WeekOfYear(DateTime.Now));
            DateTime thisWeekLastDate = thisWeekFirstDate.AddDays(7);

            AdminAuthDashboardChartDTO adminAuthDashboardChartDTO = new AdminAuthDashboardChartDTO();
            adminAuthDashboardChartDTO.NumberOfEmployees = new List<int>();
            adminAuthDashboardChartDTO.NumberOfEmployers = new List<int>();
            int maximumNumberOfEmployees = 0;
            int maximumNumberOfEmployers = 0;
            DateTime maximumNumberOfEmployeesDate = new DateTime();
            DateTime maximumNumberOfEmployersDate = new DateTime();
            for (int day = 1; day <= 7; day++)
            {
                DateTime dateTime = thisWeekFirstDate.AddDays(day - 1).Date;
                int EmployeesCOunt = employees.Where(x => (!x.CreationDate.HasValue) || x.CreationDate.Value.Date == dateTime).Count();
                int EmployersCOunt = employers.Where(x => (!x.CreationDate.HasValue) || x.CreationDate.Value.Date == dateTime).Count();
                if (EmployeesCOunt > maximumNumberOfEmployees || EmployersCOunt > maximumNumberOfEmployers)
                {
                    maximumNumberOfEmployees = EmployeesCOunt;
                    maximumNumberOfEmployeesDate = dateTime;
                    maximumNumberOfEmployers = EmployersCOunt;
                    maximumNumberOfEmployersDate = dateTime;
                }

                adminAuthDashboardChartDTO.NumberOfEmployees.Add(EmployeesCOunt);
                adminAuthDashboardChartDTO.NumberOfEmployers.Add(EmployersCOunt);
            }
            adminAuthDashboardChartDTO.MaximumNumberOfEmployeesDate = maximumNumberOfEmployeesDate;
            adminAuthDashboardChartDTO.MaximumNumberOfEmployersDate = maximumNumberOfEmployersDate;
            AdminAuthDashboardResponseDTO response = new AdminAuthDashboardResponseDTO
            {
                Dashboards = dashboards,
                Charts = adminAuthDashboardChartDTO
            };
            return response;
        }
        private async Task<IList<Claim>> BuildClaims(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id > 0 ? user.Id.ToString() : string.Empty),
                new Claim(ClaimTypes.Name, !string.IsNullOrEmpty(user.FullName) ? user.FullName : ""),
                new Claim(ClaimTypes.MobilePhone, !string.IsNullOrEmpty(user.PhoneNumber) ? user.PhoneNumber : ""),
            };
            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            return claims;
        }
        private string WriteToken(IList<Claim> claims)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfiguration.JWTKey));

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                    issuer: _appConfiguration.Issuer,
                    audience: _appConfiguration.Audience,
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddYears(100),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }
        private static DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }
        private static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
