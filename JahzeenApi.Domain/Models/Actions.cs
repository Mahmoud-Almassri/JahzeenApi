using JahzeenApi.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Domain.Models
{
    public partial class Actions : BaseModel
    {
        public int ActionType { get; set; }
        public string ActionByName { get; set; }
        public int ApprovalId { get; set; }
        [ForeignKey("ApprovalId")]
        public Approvals Approval { get; set; }
        public string Comments { get; set; }

    }
}
