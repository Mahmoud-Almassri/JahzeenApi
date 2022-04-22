using Domains.DTO;
using JahzeenApi.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Service.Interfaces
{
    public interface IAdminAuthService
    {
        Task<LoginResponseDTO> Login(AdminLoginRequestDTO model);
        Task<bool> ForgetPassword(EmployerForgetPasswordDTO forgetPassword);
        Task<bool> ResetPassword(EmployerResetPasswordDTO restPassword);
        Task<AdminAuthDashboardResponseDTO> GetDashboardData();
    }
}
