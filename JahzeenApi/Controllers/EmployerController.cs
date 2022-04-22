using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.DTO.AddDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JahzeenApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public EmployerController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpPost]
        [Authorize(Roles = "Employer")]

        public IActionResult GetHome()
        {
            try
            {
                EmployerHomeDTO response = _serviceUnitOfWork.Employer.Value.GetHomeDashboard();
                return Ok(response);

            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpGet]
        [Authorize(Roles = "Employer")]

        public IActionResult GetProfile()
        {
            try
            {
                EmployerResponseDTO employee = _serviceUnitOfWork.Employer.Value.GetProfile();
                return Ok(employee);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "SuperAdmin")]

        public IActionResult GetProfileById(int id)
        {
            try
            {
                EmployerResponseDTO employee = _serviceUnitOfWork.Employer.Value.GetProfileById(id);
                return Ok(employee);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpPost]
        [Authorize(Roles = "Employer")]

        public async Task<IActionResult> UpdateProfile(EmployerUpdateProfile Profile)
        {
            try
            {
                EmployerUpdateProfile UpdatedEntity =await _serviceUnitOfWork.Employer.Value.UpdateProfile(Profile);
                return Ok(UpdatedEntity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
