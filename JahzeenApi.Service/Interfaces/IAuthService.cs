using JahzeenApi.Domain.Models;
using System.Threading.Tasks;
using JahzeenApi.Domain.DTO;
using Domains.DTO;
using Google.Apis.Auth;

namespace Service.Interfaces
{
    public interface IEmployerAuthService
    {
        Task<LoginResponseDTO> Login(EmployerLoginRequestDTO model);
        Task<bool> ChangePassword(UpdatePasswordDTO updatePasswordDTO);
        Task<bool> ForgetPassword(EmployerForgetPasswordDTO forgetPassword);
        Task<UserRegistrationResponseDTO> SignUp(EmployerRegistrationDTO user);
        Task<bool> ResetPassword(EmployerResetPasswordDTO restPassword);
        Task<bool> ConfirmEmailAsync(EmployerConfirmAccountDTO confirmAccount);
    }
}
