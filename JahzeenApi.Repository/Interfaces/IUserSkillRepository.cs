using JahzeenApi.Domain.Models;
using Repository.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Repository.Interfaces
{
    public interface IUserSkillRepository : IRepository<UserSkill>
    {
        IEnumerable<Domain.DTO.UserSkillDTO> GetByUserId(int UserId);
    }
}
