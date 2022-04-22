using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace JahzeenApi.Domain.Models
{
    public partial class Roles : IdentityRole<int>
    {
        public Roles()
        {
            RoleClaims = new HashSet<RoleClaims>();
            UserRoles = new HashSet<UserRoles>();
        }
        public virtual ICollection<RoleClaims> RoleClaims { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
