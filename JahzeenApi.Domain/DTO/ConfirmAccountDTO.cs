using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Domain.DTO
{
    public class ConfirmAccountDTO :CommonDTO
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmCode { get; set; }
    } 
    public class EmployerConfirmAccountDTO :CommonDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmCode { get; set; }
    }
}
