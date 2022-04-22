using JahzeenApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Domain.DTO
{
    public partial class UserSkillDTO : BaseModelDTO
    {
        public int SkillId { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string SkillName { get; set; }
        public TitleLevel TitleLevel { get; set; }

    }
}
