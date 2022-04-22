using AutoMapper;
using Domains.DTO;
using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.Enums;
using JahzeenApi.Domain.Models;
using JahzeenApi.Domain.SearchModels;
using JahzeenApi.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Service.Services
{
    public class ApprovalService : IApprovalService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private IMapper _mapper;

        public ApprovalService(IRepositoryUnitOfWork repositoryUnitOfWork, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
        }

        public BaseListResponse<EmployeeApprovalDTO> EmployeeList(ApprovalSearch Search)
        {
            BaseListResponse<EmployeeApprovalDTO> EmployeeList = _repositoryUnitOfWork.Users.Value.EmployeeList(Search);
            return EmployeeList;
        }

        public BaseListResponse<EmployerApprovalDTO> EmployerList(ApprovalSearch Search)
        {
            BaseListResponse<EmployerApprovalDTO> EmployerList = _repositoryUnitOfWork.Users.Value.EmployerList(Search);
            return EmployerList;
        }

        public async Task<Approvals> ApproveAccount(ApprovalDTO approval)
        {
            #region Get Approval
            Approvals approvals = _repositoryUnitOfWork.Approval.Value.FirstOrDefault(x => x.Id == approval.ApprovalId && x.ApprovalUserName == "SuperAdmin");
            approvals.Status = BaseStatus.NotActive;
            Approvals UpdatedApproval = _repositoryUnitOfWork.Approval.Value.Update(approvals);
            #endregion

            #region Log Action
            Actions actions = new Actions
            {
                Comments = approval.Comments,
                ApprovalId = UpdatedApproval.Id,
                ActionType = (int)ActionType.Accept,
                ActionByName = UpdatedApproval.ApprovalUserName
            };
            Actions CreatedAction = _repositoryUnitOfWork.Action.Value.Add(actions);
            #endregion

            #region Update Account Status
            ApplicationUser applicationUser = _userManager.Users.FirstOrDefault(x => x.Id == approval.AccountId);
            applicationUser.ApprovalStatus = (int)ApprovalStatus.Approved;
            IdentityResult UpdatedUser =await _userManager.UpdateAsync(applicationUser);
            #endregion

            return UpdatedApproval;
        }

        public async Task<Approvals> DeclineAccount(ApprovalDTO approval)
        {
            #region Get Approval
            Approvals approvals = _repositoryUnitOfWork.Approval.Value.FirstOrDefault(x => x.Id == approval.ApprovalId && x.ApprovalUserName == "SuperAdmin");
            approvals.Status = BaseStatus.Active;
            Approvals UpdatedApproval = _repositoryUnitOfWork.Approval.Value.Update(approvals);
            #endregion

            #region Log Action
            Actions actions = new Actions
            {
                Comments = approval.Comments,
                ApprovalId = UpdatedApproval.Id,
                ActionType = (int)ActionType.ReturnForModification,
                ActionByName = UpdatedApproval.ApprovalUserName
            };
            Actions CreatedAction = _repositoryUnitOfWork.Action.Value.Add(actions);
            #endregion

            #region Update Account Status
            ApplicationUser applicationUser = _userManager.Users.FirstOrDefault(x => x.Id == approval.AccountId);
            applicationUser.ApprovalStatus = (int)ApprovalStatus.Decline;
            IdentityResult UpdatedUser = await _userManager.UpdateAsync(applicationUser);
            #endregion

            return UpdatedApproval;
        }

        public async Task<Approvals> RejectAccount(ApprovalDTO approval)
        {
            #region Get Approval
            Approvals approvals = _repositoryUnitOfWork.Approval.Value.FirstOrDefault(x => x.Id == approval.ApprovalId && x.ApprovalUserName == "SuperAdmin");
            approvals.Status = BaseStatus.NotActive;
            Approvals UpdatedApproval = _repositoryUnitOfWork.Approval.Value.Update(approvals);
            #endregion

            #region Log Action
            Actions actions = new Actions
            {
                Comments = approval.Comments,
                ApprovalId = UpdatedApproval.Id,
                ActionType = (int)ActionType.Reject,
                ActionByName = UpdatedApproval.ApprovalUserName
            };
            Actions CreatedAction = _repositoryUnitOfWork.Action.Value.Add(actions);
            #endregion

            #region Update Account Status
            ApplicationUser applicationUser = _userManager.Users.FirstOrDefault(x => x.Id == approval.AccountId);
            applicationUser.ApprovalStatus = (int)ApprovalStatus.Rejected;
            IdentityResult UpdatedUser = await _userManager.UpdateAsync(applicationUser);
            #endregion

            return UpdatedApproval;
        }
    }
}
