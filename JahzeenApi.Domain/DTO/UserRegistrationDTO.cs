using JahzeenApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JahzeenApi.Domain.DTO
{
    public partial class EmployerRegistrationDTO
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Lang { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
