using Domains.DTO;
using Domains.SearchModels;
using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.DTO.AddDTO;
using JahzeenApi.Domain.Models;
using Microsoft.AspNetCore.Http;
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
    public class ExperienceController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public ExperienceController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpPost]
        public IActionResult Create(ExperienceAddDTO experience)
        {
            try
            {
                ExperienceAddDTO PostedExperience = _serviceUnitOfWork.Experience.Value.AddEntity(experience);
                return Ok(PostedExperience);
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
        public IActionResult Update(ExperienceAddDTO experience)
        {
            try
            {
                ExperienceAddDTO UpdatedExperience = _serviceUnitOfWork.Experience.Value.UpdateEntity(experience);
                return Ok(UpdatedExperience);
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
        public IActionResult GetList(BaseSearch baseSearch)
        {
            try
            {
                BaseListResponse<ExperienceDTO> ContactUs = _serviceUnitOfWork.Experience.Value.GetList(baseSearch);
                return Ok(ContactUs);
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

        [HttpGet("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _serviceUnitOfWork.Experience.Value.Remove(Id);
                return Ok(true);
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


        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                ExperienceDTO country = _serviceUnitOfWork.Experience.Value.GetById(Id);
                return Ok(country);
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

    }
}
