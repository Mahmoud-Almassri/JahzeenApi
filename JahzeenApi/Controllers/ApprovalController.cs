using Domains.DTO;
using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.Enums;
using JahzeenApi.Domain.SearchModels;
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
    public class ApprovalController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public ApprovalController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }


        [HttpPost]
        public IActionResult EmployeeList(ApprovalSearch Search)
        {
            try
            {
                BaseListResponse<EmployeeApprovalDTO> EmployeeList = _serviceUnitOfWork.Approval.Value.EmployeeList(Search);
                return Ok(EmployeeList);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult EmployerList(ApprovalSearch Search)
        {
            try
            {

                BaseListResponse<EmployerApprovalDTO> EmployerList = _serviceUnitOfWork.Approval.Value.EmployerList(Search);
                return Ok(EmployerList);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> ApprovalWorkFlow(ApprovalDTO approval)
        {
            try
            {
                if (approval.ActionType == (int)ActionType.Accept)
                {
                    return Ok(await _serviceUnitOfWork.Approval.Value.ApproveAccount(approval));

                }
                else if (approval.ActionType == (int)ActionType.Reject)
                {
                    return Ok(await _serviceUnitOfWork.Approval.Value.RejectAccount(approval));

                }
                else if (approval.ActionType == (int)ActionType.ReturnForModification)
                {
                    return Ok(await _serviceUnitOfWork.Approval.Value.DeclineAccount(approval));

                }
                else
                {
                    throw new ValidationException("Action Type NOt Recognized");
                }
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
    }
}
