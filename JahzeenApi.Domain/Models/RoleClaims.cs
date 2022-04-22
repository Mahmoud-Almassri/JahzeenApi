using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace JahzeenApi.Domain.Models
{
    public partial class RoleClaims : IdentityRoleClaim<int>
    {
        public virtual Roles Role { get; set; }
    }
}
