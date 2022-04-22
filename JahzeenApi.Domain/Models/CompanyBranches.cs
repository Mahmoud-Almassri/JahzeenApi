using JahzeenApi.Domain.Models.Common;

namespace JahzeenApi.Domain.Models
{
    public partial class CompanyBranches : BaseModel
    {
        public int CompanyId { get; set; }
        public string BranchName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Area { get; set; }
        public virtual Company Company { get; set; }
    }
}
