using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JahzeenApi.Domain.DTO
{
    public partial class ResetPasswordDTO :CommonDTO
    {
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public partial class EmployerResetPasswordDTO : CommonDTO
    {
        public string EmailAddress { get; set; }
        public string Token { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
