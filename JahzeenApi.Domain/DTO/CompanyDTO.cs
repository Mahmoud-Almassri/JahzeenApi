using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Domain.DTO
{
    public class CompanyDTO : BaseModelDTO
    {
        public string CompanyName { get; set; }
        public IFormFile CompanyLogoPath { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonTitle { get; set; }
        public string MobileNumber { get; set; }
        public string IndustryOption { get; set; }
        public string CompanySize { get; set; }
        public IFormFile CommercialRegisterPath { get; set; }
        public IFormFile OtherAttachmentPath { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<CompanyBrachesDTO> CompanyBranches { get; set; }
    }
}
