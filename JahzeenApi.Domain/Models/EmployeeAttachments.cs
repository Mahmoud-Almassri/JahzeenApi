using JahzeenApi.Domain.Models.Common;

namespace JahzeenApi.Domain.Models
{
    public partial class EmployeeAttachments : BaseModel
    {
        public string PersonalPicturePath { get; set; }
        public string LastEducationCertificatePath { get; set; }
        public string NoCriminalRecordPath { get; set; }
        public string PersonalId { get; set; }
        public long? ApplicationUserId { get; set; }
    }
}
