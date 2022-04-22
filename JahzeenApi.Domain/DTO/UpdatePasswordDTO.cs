using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JahzeenApi.Domain.DTO
{
    public class UpdatePasswordDTO :CommonDTO
    {
        public string OldPassword { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string NewPassword { get; set; }

    }
}
