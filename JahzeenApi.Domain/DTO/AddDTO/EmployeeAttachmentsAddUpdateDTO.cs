using JahzeenApi.Domain.Models.Common;
using Microsoft.AspNetCore.Http;

namespace JahzeenApi.Domain.DTO
{
    public partial class EmployeeAttachmentsAddUpdateDTO 
    {
        public IFormFile PersonalPicture { get; set; }
        public IFormFile LastEducationCertificate { get; set; }
        public IFormFile NoCriminalRecord { get; set; }
        public IFormFile PersonalId { get; set; }
    }
}
