using JahzeenApi.Domain.Enums;
using JahzeenApi.Domain.Models.Common;

namespace JahzeenApi.Domain.Models
{
    public partial class UserSkill : BaseModel
    {
        public int SkillId { get; set; }
        public int UserId { get; set; }
        public TitleLevel TitleLevel { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
