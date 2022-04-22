using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.Enums;
using JahzeenApi.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Repository.UnitOfWork;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JahzeenApi.Domain.Models.Common;
using Service.Services.Common;
using Domains.DTO;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Google.Apis.Auth;

namespace Service.Services
{
    public class EmployerAuthService : IEmployerAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly LoggedInUserService _loggedInUserService;
        private readonly IConfiguration _configuration;
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly IConfigurationSection _goolgeSettings;
        AppConfiguration _appConfiguration = new AppConfiguration();
        private EmailSender emailSender;
        public EmployerAuthService(IConfiguration configuration, UserManager<ApplicationUser> userManager, IRepositoryUnitOfWork repositoryUnitOfWork, SignInManager<ApplicationUser> signInManager, LoggedInUserService loggedInUserService)
        {
            _loggedInUserService = loggedInUserService;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _goolgeSettings = _configuration.GetSection("GoogleAuthSettings");
            emailSender = new EmailSender();
        }

        public async Task<LoginResponseDTO> Login(EmployerLoginRequestDTO model)
        { 
            ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);
            if (string.IsNullOrEmpty(model.Lang))
            {
                model.Lang = "EN";
            }
            if (user != null)
            {
                if (user.EmailConfirmed)
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
                        string errorMessage = model.Lang == "EN" ? "Email or password is wrong" : "البريد الالكتروني او كلمة المرور خاطئ";
                        throw new ValidationException(errorMessage);
                    }
                }
                else
                {
                    string errorMessage = model.Lang == "EN" ? "Email not confimed yet" : "البريد الالكتروني غير مفعل بعد";
                    throw new ValidationException(errorMessage);
                }

            }
            else
            {
                string errorMessage = model.Lang == "EN" ? "Email or password is wrong" : "البريد الالكتروني او كلمة المرور خاطئ";
                throw new ValidationException(errorMessage);
            }
        }

      
        public async Task<bool> ChangePassword(UpdatePasswordDTO updatePasswordDTO)
        {
            int userId = _loggedInUserService.GetUserId();
            if (string.IsNullOrEmpty(updatePasswordDTO.Lang))
            {
                updatePasswordDTO.Lang = "EN";
            }
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());

            IdentityResult result = await _userManager.ChangePasswordAsync(user, updatePasswordDTO.OldPassword, updatePasswordDTO.NewPassword);
            if (result.Succeeded)
            {
                return true;
            }
            else if (result.Errors.Any())
            {
                string errorMessage = updatePasswordDTO.Lang == "EN" ? "Error while updating your password" : "حدث خطأ اثناء تحديث كلمة المرور";
                throw new ValidationException(errorMessage);
            }
            else
            {
                string errorMessage = updatePasswordDTO.Lang == "EN" ? "Error while updating your password" : "حدث خطأ اثناء تحديث كلمة المرور";
                throw new ValidationException(errorMessage);
            }
        }
        public async Task<UserRegistrationResponseDTO> SignUp(EmployerRegistrationDTO user)
        {
            if (string.IsNullOrEmpty(user.Lang))
            {
                user.Lang = "EN";
            }
            if (_userManager.Users.Any(x => x.Email == user.Email))
            {
                string errorMessage = user.Lang == "EN" ? "Email is already exists" : "البريد الالكتروني موجود مسبقا";
                throw new ValidationException(errorMessage);
            } 
            if (_userManager.Users.Any(x => x.PhoneNumber == user.PhoneNumber))
            {
                string errorMessage = user.Lang == "EN" ? "Phone Number is already exists" : "رقم الهاتف موجود مسبقا";
                throw new ValidationException(errorMessage);
            }

            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = user.Email,
                Email = user.Email,
                FullName = "",
                PhoneNumber = user.PhoneNumber,
                EmailConfirmed=false,
                PhoneNumberConfirmed=true,
                UserType = UserTypes.Employer,
                IsActive = true,
                CreationDate=DateTime.Now,
                ApprovalStatus = (int)ApprovalStatus.New
            };
            
            IdentityResult result = await _userManager.CreateAsync(applicationUser, user.Password);
            if (result.Succeeded)
            {
                var userRole = _repositoryUnitOfWork.RoleRepository.Value.FirstOrDefault(x => x.Name.Equals("Employer"));
                _repositoryUnitOfWork.UserRoles.Value.Add(new UserRoles
                {
                    RoleId = userRole.Id,
                    UserId = applicationUser.Id,
                });

                Random generator = new Random();
                string randomCode = "123456"; //generator.Next(0, 1000000).ToString("D6");
                if (!string.IsNullOrEmpty(randomCode))
                {
                    _repositoryUnitOfWork.RoleRepository.Value.SetUserToken(applicationUser.Id, randomCode);
                    //emailSender.sendEmailConfirmationEmail(applicationUser, randomCode);
                }
                

                Approvals approvals = CreateApproval(applicationUser.Id);
                Approvals CreatedApproval = _repositoryUnitOfWork.Approval.Value.Add(approvals);

                UserRegistrationResponseDTO responseDTO = new UserRegistrationResponseDTO
                {
                    UserId = applicationUser.Id,
                    Email = applicationUser.Email,
                    FullName = applicationUser.FullName,
                    UserName = applicationUser.UserName
                };
                return responseDTO;
            }
            else
            {
                string errorMessage = user.Lang == "EN" ? "Error while creating your account" : "حدث خطأ اثناء انشاء الحساب الخاص بك";
                throw new ValidationException(errorMessage);
            }

        }

        private async Task<IList<Claim>> BuildClaims(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id > 0 ? user.Id.ToString() : string.Empty),
                new Claim(ClaimTypes.Name, !string.IsNullOrEmpty(user.FullName) ? user.FullName : ""),
                new Claim(ClaimTypes.MobilePhone, !string.IsNullOrEmpty(user.PhoneNumber) ? user.PhoneNumber : ""),
               // new Claim(ClaimTypes.StreetAddress, !string.IsNullOrEmpty(user.Address) ? user.Address : "")
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

        public async Task<bool> ForgetPassword(EmployerForgetPasswordDTO forgetPassword)
        {
            if (string.IsNullOrEmpty(forgetPassword.Lang))
            {
                forgetPassword.Lang = "EN";
            }
            if (!string.IsNullOrEmpty(forgetPassword.EmailAddress) && _userManager.Users.Any(x => x.Email.Equals(forgetPassword.EmailAddress)))
            {
                ApplicationUser user = _userManager.Users.FirstOrDefault(x => x.Email.Equals(forgetPassword.EmailAddress));

                string token = await _userManager.GenerateTwoFactorTokenAsync(user, "SMSProvider");
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                    Random generator = new Random();
                    string randomCode = "123456"; //generator.Next(0, 1000000).ToString("D6");
                    string message = "Your reset password token from businicity is :" + randomCode;
                    _repositoryUnitOfWork.RoleRepository.Value.SetUserToken(user.Id, randomCode);
                    _repositoryUnitOfWork.RoleRepository.Value.SetUser2FAToken(user.Id, token);
                    _repositoryUnitOfWork.RoleRepository.Value.SetUserResetToken(user.Id, resetToken);
                //emailSender.sendResetPasswordSMS(message, user.PhoneNumber);
                return true;
            }
            else
            {
                string errorMessage = forgetPassword.Lang == "EN" ? "Your email not correct" : "رقم الهاتف غير صحيح";
                throw new ValidationException(errorMessage);
            }
        }

        public async Task<bool> ResetPassword(EmployerResetPasswordDTO resetPassword)
        {
            if (string.IsNullOrEmpty(resetPassword.Lang))
            {
                resetPassword.Lang = "EN";
            }
            var user = await _userManager.FindByEmailAsync(resetPassword.EmailAddress);
            if (user != null)
            {
                string validationToken = _repositoryUnitOfWork.RoleRepository.Value.ValidateResetToken(user.Id);
                var result = await _userManager.ResetPasswordAsync(user, validationToken, resetPassword.Password);
                if (result.Succeeded)
                {
                    return true;
                }
                string error = resetPassword.Lang == "EN" ? "Error while reset password" : "حدث خطأ اثناء تغيير كلمة المرور";
                throw new ValidationException(error);

            }
            string errorMessage = resetPassword.Lang == "EN" ? "Error while reset password" : "حدث خطأ اثناء تغيير كلمة المرور";
            throw new ValidationException(errorMessage);
        }

        public async Task<bool> ConfirmEmailAsync(EmployerConfirmAccountDTO confirmAccount)
        {
            if (string.IsNullOrEmpty(confirmAccount.Lang))
            {
                confirmAccount.Lang = "EN";
            }
            var user = await _userManager.FindByEmailAsync(confirmAccount.Email);
            if (user != null)
            {
                //var result = await _userManager.ConfirmEmailAsync(user, token);
                confirmAccount.ConfirmCode = confirmAccount.ConfirmCode.Replace(' ', '+');
                var result = _repositoryUnitOfWork.RoleRepository.Value.ValidateUserToken(user.Id, confirmAccount.ConfirmCode);
                if (result)
                {
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                    return true;
                }
                string errorMessage = confirmAccount.Lang == "EN" ? "Your validation code not valid" : "رمز التفعيل غير صالح ";
                throw new ValidationException(errorMessage);
            }
            string error = confirmAccount.Lang == "EN" ? "Error while activating your account" : "حدث خطأ اثناء تفعيل حسابك ";
            throw new ValidationException(error);

        }

        public async Task<bool> UpdateRegistedUser(UpdateUserRegistrationDTO updateUserRegistrationDTO)
        {
            ApplicationUser user =  _userManager.Users.FirstOrDefault(x => x.Id == updateUserRegistrationDTO.ApplicationUserId);
            if(user != null)
            {
                user.Longitude = updateUserRegistrationDTO.Longitude;
                user.Latitude = updateUserRegistrationDTO.Latitude;

                var res = await _userManager.UpdateAsync(user);
                return true;
            }
            else
            {
                throw new ValidationException("");
            }

        }

        private Approvals CreateApproval(int UserId)
        {
            Approvals approval = new Approvals
            {
                AccountId = UserId,
                CreatedById = UserId,
                ApprovalUserName = "SuperAdmin",
                ActionType = (int)ActionType.Submit,
                Status = BaseStatus.Active
            };
            return approval;
        }
    }
}
