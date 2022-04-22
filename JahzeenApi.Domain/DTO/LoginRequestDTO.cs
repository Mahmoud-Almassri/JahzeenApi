using System;
using System.Collections.Generic;
using System.Text;

namespace JahzeenApi.Domain.DTO
{
    public class LoginRequestDTO : CommonDTO
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
    public class AdminLoginRequestDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class EmployerLoginRequestDTO : CommonDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
