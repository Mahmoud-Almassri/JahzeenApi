using Domains.DTO;
using Domains.SearchModels;
using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.SearchModels;

namespace JahzeenApi.Repository.Interfaces
{
    public interface IUsersRepository
    {
        BaseListResponse<EmployerApprovalDTO> EmployerList(ApprovalSearch Search);
        BaseListResponse<EmployeeApprovalDTO> EmployeeList(ApprovalSearch Search);
        BaseListResponse<RegisteredUserResponseDTO> GetRegisteredUsers(UserSearch Search);
    }
}
