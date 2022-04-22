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
    public interface IExperienceService : IService<Experience>
    {
        ExperienceAddDTO AddEntity(ExperienceAddDTO experience);
        ExperienceAddDTO UpdateEntity(ExperienceAddDTO experience);
        BaseListResponse<ExperienceDTO> GetList(BaseSearch baseSearch);
        public ExperienceDTO GetById(int Id);
    }
}
