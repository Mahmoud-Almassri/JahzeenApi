using JahzeenApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Domain.DTO.AddDTO
{
    public partial class UserSkillAddDTO : BaseModelDTO
    {
        public long SkillId { get; set; }
        public long UserId { get; set; }
        public TitleLevel TitleLevel { get; set; }
    }
}
