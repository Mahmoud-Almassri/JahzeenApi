using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace JahzeenApi.Domain.Models
{
    public partial class UserLogins : IdentityUserLogin<int>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
