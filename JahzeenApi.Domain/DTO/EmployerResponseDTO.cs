using JahzeenApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Domain.DTO
{
    public class EmployerResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogoPath { get; set; }
        public string OtherAttachmentPath { get; set; }
        public string CommercialRegisterPath { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonTitle { get; set; }
        public string ContactPersonMobileNumber { get; set; }
        public string IndustryOption { get; set; }
        public string CompanySize { get; set; }
        public virtual ICollection<CompanyBrachesDTO> CompanyBranches { get; set; }


    }
}
