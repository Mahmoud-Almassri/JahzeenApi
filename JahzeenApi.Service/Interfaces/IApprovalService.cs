using Domains.DTO;
using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.Models;
using JahzeenApi.Domain.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Service.Interfaces
{
    public interface IApprovalService
    {
        BaseListResponse<EmployeeApprovalDTO> EmployeeList(ApprovalSearch Search);
        BaseListResponse<EmployerApprovalDTO> EmployerList(ApprovalSearch Search);
        Task<Approvals> ApproveAccount(ApprovalDTO approval);
        Task<Approvals> DeclineAccount(ApprovalDTO approval);
        Task<Approvals> RejectAccount(ApprovalDTO approval);


    }
}
