using JahzeenApi.Domain.Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JahzeenApi.Domain.Models
{
    public partial class Company : BaseModel
    {
        public Company()
        {
            CompanyBranches = new HashSet<CompanyBranches>();
        }
        public string CompanyName { get; set; }
        public string CompanyLogoPath { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonTitle { get; set; }
        public string MobileNumber { get; set; }
        public string IndustryOption { get; set; }
        public string CompanySize { get; set; }
        public string CommercialRegisterPath { get; set; }
        public string OtherAttachmentPath { get; set; }
        public int UserId { get; set; }
        public int ApprovalId { get; set; }
        public virtual Approvals Approval { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public virtual ICollection<CompanyBranches> CompanyBranches { get; set; }
    }
}
