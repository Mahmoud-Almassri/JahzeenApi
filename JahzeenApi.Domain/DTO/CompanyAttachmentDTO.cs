using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Domain.DTO
{
    public class CompanyAttachmentDTO
    {
        public IFormFile CompnayLogo { get; set; }
        public IFormFile CommercialRegister { get; set; }
        public IFormFile OtherAttachment { get; set; }
        public string CompanyLogoPath { get; set; }
        public string CommercialRegisterPath { get; set; }
        public string OtherAttachmentPath { get; set; }
    }
}
