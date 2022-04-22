using JahzeenApi.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace JahzeenApi.Controllers.auth
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeAuthController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public EmployeeAuthController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequestDTO user)
        {
            try
            {

                LoginResponseDTO res = await _serviceUnitOfWork.EmployeeAuth.Value.Login(user);
                return Ok(res);
            }
            catch (ValidationException e)
            {

                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] UpdatePasswordDTO updatePasswordDTO)
        {
            try
            {
                bool result = await _serviceUnitOfWork.EmployeeAuth.Value.ChangePassword(updatePasswordDTO);
                return Ok(result);
            }
            catch (ValidationException e)
            {

                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgetPassword(EmployeeForgetPasswordDTO forgetPasswordDTO)
        {
            try
            {
                var res = await _serviceUnitOfWork.EmployeeAuth.Value.ForgetPassword(forgetPasswordDTO);
                return Ok(res);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> ResetPassword(ResetPasswordDTO restPasswordDTO)
        {
            try
            {
                restPasswordDTO.Token = restPasswordDTO.Token.Replace(' ', '+');
                var res = await _serviceUnitOfWork.EmployeeAuth.Value.ResetPassword(restPasswordDTO);
                return Ok(res);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Signup(EmployeeRegisterationDTO user)
        {
            try
            {

                UserRegistrationResponseDTO res = await _serviceUnitOfWork.EmployeeAuth.Value.Signup(user);
                return Ok(res);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmAccount(ConfirmAccountDTO confirmAccount)
        {
            try
            {
                var res = await _serviceUnitOfWork.EmployeeAuth.Value.ConfirmAccountAsync(confirmAccount);
                return Ok(res);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
