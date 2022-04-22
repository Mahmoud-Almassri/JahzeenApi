using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace JahzeenApi.Domain.Models
{
    public partial class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            UserClaims = new HashSet<UserClaims>();
            UserLogins = new HashSet<UserLogins>();
            UserRoles = new HashSet<UserRoles>();
            UserTokens = new HashSet<UserTokens>();
        }
        public string FullName { get; set; }
        public bool? IsActive { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string LastEducationLevel { get; set; }
        public Enums.Gender? Gender { get; set; }
        public Enums.UserTypes UserType { get; set; }
        public int? YearOfBirth { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int? ApprovalStatus { get; set; }
        public bool? NoPrevExperience { get; set; }
        public virtual ICollection<UserClaims> UserClaims { get; set; }
        public virtual ICollection<UserLogins> UserLogins { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
        public virtual ICollection<UserTokens> UserTokens { get; set; }
    }
}
