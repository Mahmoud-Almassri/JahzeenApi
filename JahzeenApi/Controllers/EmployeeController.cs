using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.DTO.AddDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace JahzeenApi.Controllers.auth
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public EmployeeController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]

        public IActionResult GetHome()
        {
            try
            {
                EmployeeHomeDTO response = _serviceUnitOfWork.Employee.Value.GetHomeDashboard();
                return Ok(response);

            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpGet]
        [Authorize(Roles = "Employee")]

        public IActionResult GetProfile()
        {
            try
            {
                EmployeeResponseDTO employee = _serviceUnitOfWork.Employee.Value.GetProfile();
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
                EmployeeResponseDTO employee = _serviceUnitOfWork.Employee.Value.GetProfileById(id);
                return Ok(employee);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> UpdateProfile(EmployeeUpdateProfile profile)
        {
            try
            {
                EmployeeUpdateProfile UpdatedEntity =await _serviceUnitOfWork.Employee.Value.UpdateProfile(profile);
                return Ok(UpdatedEntity);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
