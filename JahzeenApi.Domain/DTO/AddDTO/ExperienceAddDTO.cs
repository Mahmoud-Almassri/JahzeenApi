using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Domain.DTO.AddDTO
{
    public partial class ExperienceAddDTO : BaseModelDTO
    {
        public bool? NoPrevExperience { get; set; }
        public int? ExperienceType { get; set; }
        public string JobTitle { get; set; }
        public string Employer { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public long? ApplicationUserId { get; set; }
    }
}
