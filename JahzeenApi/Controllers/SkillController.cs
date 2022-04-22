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
    public class SkillController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public SkillController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpPost]
        public IActionResult Create(SkillAddDTO skill)
        {
            try
            {
                SkillAddDTO PostedSkill = _serviceUnitOfWork.Skill.Value.AddEntity(skill);
                return Ok(PostedSkill);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {

                throw ;
            }
        }

        [HttpPost]
        public IActionResult Update(SkillAddDTO skill)
        {
            try
            {
                SkillAddDTO UpdatedSkill = _serviceUnitOfWork.Skill.Value.UpdateEntity(skill);
                return Ok(UpdatedSkill);
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
                BaseListResponse<SkillDTO> Skill = _serviceUnitOfWork.Skill.Value.GetList(baseSearch);
                return Ok(Skill);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {

                throw ;
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<SkillDTO> Skill = _serviceUnitOfWork.Skill.Value.GetAllEntities();
                return Ok(Skill);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {

                throw ;
            }
        }

        [HttpGet("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _serviceUnitOfWork.Skill.Value.Remove(Id);
                return Ok(true);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {

                throw ;
            }
        }


        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                SkillDTO country = _serviceUnitOfWork.Skill.Value.GetById(Id);
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
