using AutoMapper;
using Domain;
using Domains.DTO;
using Domains.SearchModels;
using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.Enums;
using JahzeenApi.Domain.Models;
using JahzeenApi.Domain.Models.Common;
using JahzeenApi.Domain.SearchModels;
using JahzeenApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Repository.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private JahzeenContext _context;
        private IMapper _mapper;
        AppConfiguration _appConfiguration = new AppConfiguration();

        public UsersRepository(JahzeenContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public BaseListResponse<EmployeeApprovalDTO> EmployeeList(ApprovalSearch Search)
        {

            IEnumerable<Approvals> approvals = _context.Approvals.Include(x => x.Account).Where(x =>
              (x.Account.UserType == UserTypes.Employee) &&
              (string.IsNullOrEmpty(Search.Name) || x.Account.FullName.Contains(Search.Name)) &&
              (string.IsNullOrEmpty(Search.PhoneNumber) || x.Account.PhoneNumber.Contains(Search.PhoneNumber)) &&
              (string.IsNullOrEmpty(Search.UserName) || x.Account.UserName.Contains(Search.UserName)) &&
                                                                                 (!Search.FromDate.HasValue || x.ModifiedDate >= Search.FromDate) &&
                                                                     (!Search.ToDate.HasValue || x.ModifiedDate <= Search.ToDate) &&
              x.Account.ApprovalStatus == (int)ApprovalStatus.submittedForApproval);

            BaseListResponse<Approvals> Response = new BaseListResponse<Approvals>
            {
                Entities = approvals.Skip(_appConfiguration.PageSize * (Search.PageNumber - 1)).Take(_appConfiguration.PageSize).ToList(),
                TotalCount = approvals.Count()
            };

            List<EmployeeApprovalDTO> EmployeeList = _mapper.Map<List<EmployeeApprovalDTO>>(Response.Entities);
            return new BaseListResponse<EmployeeApprovalDTO>
            {
                Entities = EmployeeList,
                TotalCount = Response.TotalCount
            };

        }
        public BaseListResponse<RegisteredUserResponseDTO> GetRegisteredUsers(UserSearch Search)
        {
            IEnumerable<ApplicationUser> FilteredEmployee = _context.ApplicationUser.Where(x =>
                                                                   (x.UserRoles.Any(y => y.Role.Name == Search.RoleName)) &&
                                                                   (!Search.FromDate.HasValue || x.CreationDate >= Search.FromDate) &&
                                                                   (!Search.ToDate.HasValue || x.CreationDate <= Search.ToDate) &&
                                                                   (string.IsNullOrEmpty(Search.UserName) || x.UserName.Contains(Search.UserName))&&
                                                                   x.ApprovalStatus == (int)ApprovalStatus.Approved);

            BaseListResponse<ApplicationUser> Response = new BaseListResponse<ApplicationUser>
            {
                Entities = FilteredEmployee.Skip(_appConfiguration.PageSize * (Search.PageNumber - 1)).Take(_appConfiguration.PageSize).ToList(),
                TotalCount = FilteredEmployee.Count()
            };

            List<RegisteredUserResponseDTO> EmployeeList = _mapper.Map<List<RegisteredUserResponseDTO>>(Response.Entities);
            return new BaseListResponse<RegisteredUserResponseDTO>
            {
                Entities = EmployeeList,
                TotalCount = Response.TotalCount
            };

        }

        public BaseListResponse<EmployerApprovalDTO> EmployerList(ApprovalSearch Search)
        {
            IEnumerable<Company> FilteredEmployer = _context.Company.Include(x => x.Approval).ThenInclude(x => x.Account).Where(x =>
                                                                                            (x.Approval.Account.UserType == UserTypes.Employer) &&
                                                                                           (string.IsNullOrEmpty(Search.Name) || x.Approval.Account.FullName.Contains(Search.Name))
                                                                                           && (string.IsNullOrEmpty(Search.PhoneNumber) || x.Approval.Account.PhoneNumber.Contains(Search.PhoneNumber))
                                                                                           && (string.IsNullOrEmpty(Search.UserName) || x.CompanyName.Contains(Search.UserName))
                                                                                           && (!Search.FromDate.HasValue || x.ModifiedDate >= Search.FromDate)
                                                                                           && (!Search.ToDate.HasValue || x.ModifiedDate <= Search.ToDate)
                                                                       && x.Approval.Account.ApprovalStatus == (int)ApprovalStatus.submittedForApproval)
                                                                        .Include(y => y.CompanyBranches);

            BaseListResponse<Company> Response = new BaseListResponse<Company>
            {
                Entities = FilteredEmployer.Skip(_appConfiguration.PageSize * (Search.PageNumber - 1)).Take(_appConfiguration.PageSize).ToList(),
                TotalCount = FilteredEmployer.Count()
            };

            List<EmployerApprovalDTO> EmployerList = _mapper.Map<List<EmployerApprovalDTO>>(Response.Entities);
            return new BaseListResponse<EmployerApprovalDTO>
            {
                Entities = EmployerList,
                TotalCount = Response.TotalCount
            };

        }
    }
}
