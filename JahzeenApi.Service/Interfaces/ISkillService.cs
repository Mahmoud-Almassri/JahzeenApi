using Domains.DTO;
using Domains.SearchModels;
using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.DTO.AddDTO;
using JahzeenApi.Domain.Models;
using Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Service.Interfaces
{
    public interface ISkillService : IService<Skill>
    {
        SkillAddDTO AddEntity(SkillAddDTO skill);
        SkillAddDTO UpdateEntity(SkillAddDTO skill);
        BaseListResponse<SkillDTO> GetList(BaseSearch baseSearch);
        public SkillDTO GetById(int Id);
        List<SkillDTO> GetAllEntities();
    }
}
