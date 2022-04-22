using System;
using System.Collections.Generic;
using System.Text;

namespace JahzeenApi.Domain.DTO
{
    public class EmployeeForgetPasswordDTO :CommonDTO
    {
        public string PhoneNumber { get; set; }
        public string Language { get; set; }
    }
    public class EmployerForgetPasswordDTO :CommonDTO
    {
        public string EmailAddress { get; set; }
        public string Language { get; set; }
    }
}
