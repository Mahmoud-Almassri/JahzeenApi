using JahzeenApi.Domain.Models.Common;
using System.Collections.Generic;

namespace JahzeenApi.Domain.Models
{
    public partial class Skill : BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
