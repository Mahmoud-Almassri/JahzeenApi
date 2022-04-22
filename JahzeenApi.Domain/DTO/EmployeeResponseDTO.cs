using JahzeenApi.Domain.Models;
using System;
using System.Collections.Generic;

namespace JahzeenApi.Domain.DTO
{
    public class EmployeeResponseDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Enums.Gender? Gender { get; set; }
        public int? YearOfBirth { get; set; }
        public int? ApprovalStatus { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LastEducationLevel { get; set; }
        public string CreationDate { get; set; }
        public bool? NoPrevExperience { get; set; }
        public EmployeeAttachmentDTO Attachment { get; set; }
        public virtual ICollection<UserSkillDTO> UserSkill { get; set; }
        public virtual ICollection<ExperienceDTO> UserExperience { get; set; }

    }
}
