using Domains.DTO;
using JahzeenApi.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JahzeenApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminAuthController : Controller
    {
        public AdminAuthController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        private readonly IServiceUnitOfWork _serviceUnitOfWork;

        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginRequestDTO loginDTO)
        {
            try
            {
                LoginResponseDTO tokenResponseDTO = await _serviceUnitOfWork.AdminAuth.Value.Login(loginDTO);
                return Ok(tokenResponseDTO);

            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgetPassword(EmployerForgetPasswordDTO forgetPasswordDTO)
        {
            var res = await _serviceUnitOfWork.AdminAuth.Value.ForgetPassword(forgetPasswordDTO);
            return Ok(res);
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> ResetPassword(EmployerResetPasswordDTO restPasswordDTO)
        {
            restPasswordDTO.Token = restPasswordDTO.Token.Replace(' ', '+');
            var res = await _serviceUnitOfWork.AdminAuth.Value.ResetPassword(restPasswordDTO);
            return Ok(res);
        }
       

        [HttpGet]
        public async Task<IActionResult> GetDashboardData()
        {
            try
            {
                AdminAuthDashboardResponseDTO dashboardDTOs = await _serviceUnitOfWork.AdminAuth.Value.GetDashboardData();
                return Ok(dashboardDTOs);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
