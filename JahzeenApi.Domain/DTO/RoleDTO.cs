﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace JahzeenApi.Domain.DTO
{
    public partial class RoleDTO 
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
