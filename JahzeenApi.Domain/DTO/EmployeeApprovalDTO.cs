using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Domain.DTO
{
    public class EmployeeApprovalDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string FullName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Enums.Gender? Gender { get; set; }
        public int? YearOfBirth { get; set; }
        public int? ApprovalStatus { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
