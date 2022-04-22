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
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace JahzeenApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class WebEmployeeAuthController : Controller
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public WebEmployeeAuthController(IServiceUnitOfWork serviceUnitOfWork,
            IWebHostEnvironment webHostEnvironmen)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
            _webHostEnvironment = webHostEnvironmen;
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
        public async Task<IActionResult> ConfirmAccount(ConfirmAccountDTO confirmAccount)
        {
            try
            {
                LoginRequestDTO res = await _serviceUnitOfWork.EmployeeAuth.Value.ConfirmAccountAsync(confirmAccount);
                LoginResponseDTO tokenResponseDTO = await _serviceUnitOfWork.EmployeeAuth.Value.Login(res);
                return Ok(tokenResponseDTO);
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
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> UpdateProfile([FromBody] EmployeeUpdateProfile profile)
        {
            try
            {
                EmployeeUpdateProfile UpdatedEntity = await _serviceUnitOfWork.Employee.Value.UpdateProfile(profile);
                return Ok(UpdatedEntity);
            }
            catch (Exception e)
            {

                throw;
            }
        }  
        //*
        //*/
        [HttpPost]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> UploadProfileAttachment([FromForm] EmployeeAttachmentsAddUpdateDTO attachments)
        {
            try
            {
                EmployeeAttachmentsAddUpdateDTO UploadedAttachments = await _serviceUnitOfWork.Employee.Value.UploadProfileAttachment(attachments);
                return Ok(UploadedAttachments);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public ActionResult DeleteEmployeeSkill(UserSkillDTO skill)
        {
            try
            {
                 _serviceUnitOfWork.UserSkill.Value.Remove(skill.Id);
                return Ok();
            }
            catch (Exception e)
            {

                throw;
            }
        }
        [HttpPost]
        [Authorize(Roles = "Employee")]
        public IActionResult DeleteEmployeeExperience(ExperienceDTO experience)
        {
            try
            {
                 _serviceUnitOfWork.Experience.Value.Remove(experience.Id);
                return Ok();
            }
            catch (Exception e)
            {

                throw;
            }
        }
        [HttpPost]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> AddUserSkill(UserSkill userSkill)
        {
            try
            {
                 _serviceUnitOfWork.UserSkill.Value.Add(userSkill);
                return Ok();
            }
            catch (Exception e)
            {

                throw;
            }
        }
        [HttpPost]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> AddUserExperience(Experience experience)
        {
            try
            {
                 _serviceUnitOfWork.Experience.Value.Add(experience);
                return Ok();
            }
            catch (Exception e)
            {

                throw;
            }
        }
        [HttpGet]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult> DownloadEmployeeFile(string filePath)
        {
            try
            {
                string directory = _webHostEnvironment.WebRootPath + "\\home\\employee-attachments\\" + filePath;
                var bytes = await System.IO.File.ReadAllBytesAsync(directory);
                return File(bytes, "text/plain", Path.GetFileName(directory));
            }
            catch (Exception e)
            {

                throw;
            }

        }
        [HttpGet]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult> GetEmployeeAttachments()
        {
            try
            {
                EmployeeAttachments employeeAttachments = await _serviceUnitOfWork.Employee.Value.GetEmployeeAttachments();
                return Ok(employeeAttachments);
            }
            catch (Exception e)
            {

                throw;
            }

        }


    }
}
