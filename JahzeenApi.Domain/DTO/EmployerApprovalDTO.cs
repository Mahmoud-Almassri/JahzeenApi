using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Domain.DTO
{
    public class EmployerApprovalDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int ApprovalId { get; set; }
        public string FullName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? ApprovalStatus { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string IndustryOption { get; set; }
        public string CompanySize { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
