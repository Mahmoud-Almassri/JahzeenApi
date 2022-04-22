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
    public class EmployerAuthController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public EmployerAuthController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Login(EmployerLoginRequestDTO loginDTO)
        {
            try
            {

                LoginResponseDTO res = await _serviceUnitOfWork.EmployerAuth.Value.Login(loginDTO);
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
                bool result = await _serviceUnitOfWork.EmployerAuth.Value.ChangePassword(updatePasswordDTO);
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
        public async Task<IActionResult> ForgetPassword(EmployerForgetPasswordDTO forgetPasswordDTO)
        {
            try
            {
                var res = await _serviceUnitOfWork.EmployerAuth.Value.ForgetPassword(forgetPasswordDTO);
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

        public async Task<IActionResult> ResetPassword(EmployerResetPasswordDTO restPasswordDTO)
        {
            try
            {
                restPasswordDTO.Token = restPasswordDTO.Token.Replace(' ', '+');
                var res = await _serviceUnitOfWork.EmployerAuth.Value.ResetPassword(restPasswordDTO);
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
        public async Task<IActionResult> Signup(EmployerRegistrationDTO user)
        {
            try
            {

                UserRegistrationResponseDTO res = await _serviceUnitOfWork.EmployerAuth.Value.SignUp(user);
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
        public async Task<IActionResult> ConfirmEmail(EmployerConfirmAccountDTO confirmAccount)
        {
            try
            {
                var res = await _serviceUnitOfWork.EmployerAuth.Value.ConfirmEmailAsync(confirmAccount);
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
