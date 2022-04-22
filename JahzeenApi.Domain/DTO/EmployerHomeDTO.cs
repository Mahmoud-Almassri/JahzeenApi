using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace JahzeenApi.Domain.DTO
{
    public partial class EmployerHomeDTO
    {
       
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string ProfileCompleteness { get; set; }
        public string ProfileImgUrl { get; set; }
    }
}
