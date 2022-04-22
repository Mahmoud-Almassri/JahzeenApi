using Domains.DTO;
using Domains.SearchModels;
using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.DTO.AddDTO;
using JahzeenApi.Domain.Models;
using Service.Interfaces.Common;

namespace JahzeenApi.Service.Interfaces
{
    public interface IUserSkillService : IService<UserSkill>
    {
        UserSkillAddDTO AddEntity(UserSkillAddDTO skill);
        UserSkillAddDTO UpdateEntity(UserSkillAddDTO skill);
        BaseListResponse<UserSkillDTO> GetList(BaseSearch baseSearch);
        public UserSkillDTO GetById(int Id);
        System.Collections.Generic.IEnumerable<UserSkillDTO> GetByUserId(int UserId);
    }
}
