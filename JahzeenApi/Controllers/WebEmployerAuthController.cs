using JahzeenApi.Domain.DTO;
using Domains.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using JahzeenApi.Domain.DTO.AddDTO;
using JahzeenApi.Domain.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace JahzeenApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WebEmployerAuthController : Controller
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public WebEmployerAuthController(IServiceUnitOfWork serviceUnitOfWork,
            IWebHostEnvironment webHostEnvironmen)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
            _webHostEnvironment = webHostEnvironmen;
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

                return BadRequest(e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(EmployerLoginRequestDTO user)
        {
            try
            {

                LoginResponseDTO res = await _serviceUnitOfWork.EmployerAuth.Value.Login(user);
                return Ok(res);
            }
            catch (ValidationException e)
            {

                return BadRequest(e);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmAccount(EmployerConfirmAccountDTO confirmAccount)
        {
            try
            {
                var res = await _serviceUnitOfWork.EmployerAuth.Value.ConfirmEmailAsync(confirmAccount);
                if (res)
                {
                    EmployerLoginRequestDTO loginDTO = new EmployerLoginRequestDTO();
                    loginDTO.Email = confirmAccount.Email;
                    loginDTO.Password = confirmAccount.Password;
                    LoginResponseDTO tokenResponseDTO = await _serviceUnitOfWork.EmployerAuth.Value.Login(loginDTO);
                    return Ok(tokenResponseDTO);
                }
                string error = "Error while activating your account" ;
                return BadRequest(error);

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
        [Authorize(Roles = "Employer")]
        public async Task <IActionResult> UpdateProfile(EmployerUpdateProfile Profile)
        {
            try
            {
                EmployerUpdateProfile UpdatedEntity = await _serviceUnitOfWork.Employer.Value.UpdateProfile(Profile);
                return Ok(UpdatedEntity);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [HttpPost]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> UploadProfileAttachment([FromForm] EmployerAttachmentsAddUpdateDTO attachments)
        {
            try
            {
                EmployerAttachmentsAddUpdateDTO UploadedAttachments = await _serviceUnitOfWork.Employer.Value.UploadProfileAttachment(attachments);
                return Ok(UploadedAttachments);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        [HttpGet]
        [Authorize(Roles = "Employer")]
        public async Task<ActionResult> DownloadEmployerFile(string filePath)
            {
            try
            {
                string directory = _webHostEnvironment.WebRootPath + "\\home\\employer-attachments\\" + filePath;
                var bytes = await System.IO.File.ReadAllBytesAsync(directory);
                return File(bytes, "text/plain", Path.GetFileName(directory));
            }
            catch (Exception e)
            {

                throw;
            }
            
        }
        //[HttpPost]
        //[Authorize(Roles = "Employer")]
        //public async Task<IActionResult> AddCompanyBranch(EmployerUpdateProfile Profile)
        //{
        //    try
        //    {
        //        _serviceUnitOfWork.Employer.Value.Add(Profile);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {

        //        throw;
        //    }
        //}
    }
}
