using JahzeenApi.Domain.Models.Common;
using System;

namespace JahzeenApi.Domain.Models
{
    public partial class Experience : BaseModel
    {
        public int? ExperienceType { get; set; }
        public string JobTitle { get; set; }
        public string Employer { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public long? ApplicationUserId { get; set; }
    }
}
