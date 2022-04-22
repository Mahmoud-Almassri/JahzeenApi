using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace JahzeenApi.Domain.Models
{
    public partial class UserRoles : IdentityUserRole<int>
    {
        public virtual Roles Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
