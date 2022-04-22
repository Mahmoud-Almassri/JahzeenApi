using JahzeenApi.Domain.Models.Common;
using Microsoft.AspNetCore.Http;

namespace JahzeenApi.Domain.DTO.AddDTO
{
    public class EmployerAttachmentsAddUpdateDTO
    {
        public IFormFile CompanyLogoPath { get; set; }
        public IFormFile CommercialRegisterPath { get; set; }
        public IFormFile OtherAttachmentPath { get; set; }
    }
}
