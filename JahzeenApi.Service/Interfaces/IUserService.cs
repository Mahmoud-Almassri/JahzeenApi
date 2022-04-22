using JahzeenApi.Domain.DTO;
using Domain.SearchModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domains.DTO;
using Domains.SearchModels;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDTO> Register(RegisterDTO model);
        Task<UserResponseDTO> UpdateUserInfo(UserRequestDTO userInfo);
        Task<bool> RemoveUser(int userId);
        Task<ListResponse<UserResponseDTO>> GetUsersList(UserSearchModel search);
        Task<UserResponseDTO> GetUserInfo(int userId);
        Task<UserProfileResponseDTO> GetUserProfile();
        Task<UserProfileResponseDTO> UpdateUserProfile(UserProfileRequestDTO userProfile);
        IList<RoleDTO> GetRoles();
        BaseListResponse<RegisteredUserResponseDTO> GetRegisteredUsers(UserSearch search);
    }
}


