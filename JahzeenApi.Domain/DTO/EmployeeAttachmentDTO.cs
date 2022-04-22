using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Domain.DTO
{
    public class EmployeeAttachmentDTO
    {
        public int Id { get; set; }
        public string PersonalPicturePath { get; set; }
        public string LastEducationCertificatePath { get; set; }
        public string NoCriminalRecordPath { get; set; }
        public string PersonalId { get; set; }
        public int? ApplicationUserId { get; set; }
    }
}
