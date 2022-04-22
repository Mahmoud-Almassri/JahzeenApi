using JahzeenApi.Domain.Enums;
using JahzeenApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Domain.DTO.AddDTO
{
    public partial class EmployeeUpdateProfile  :CommonDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? YearOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string LastEducationLevel { get; set; }
        public bool? NoPrevExperience { get; set; }

        public ICollection<ExperienceDTO> Experiences { get; set; }
        public EmployeeAttachmentsAddUpdateDTO Attachments { get; set; }
        public ICollection<UserSkillAddDTO> Skills { get; set; }
    }
}
