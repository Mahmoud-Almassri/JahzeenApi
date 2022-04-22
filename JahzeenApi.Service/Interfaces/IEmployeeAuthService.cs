using JahzeenApi.Domain.Models;
using System.Threading.Tasks;
using JahzeenApi.Domain.DTO;
using Domains.DTO;
using Google.Apis.Auth;

namespace Service.Interfaces
{
    public interface IEmployeeAuthService
    {
        Task<LoginResponseDTO> Login(LoginRequestDTO model);
        Task<bool> ChangePassword(UpdatePasswordDTO updatePasswordDTO);
        Task<bool> ForgetPassword(EmployeeForgetPasswordDTO forgetPassword);
        Task<UserRegistrationResponseDTO> Signup(EmployeeRegisterationDTO user);
        Task<bool> ResetPassword(ResetPasswordDTO restPassword);
        Task<LoginRequestDTO> ConfirmAccountAsync(ConfirmAccountDTO confirmAccountDTO);
    }
}
