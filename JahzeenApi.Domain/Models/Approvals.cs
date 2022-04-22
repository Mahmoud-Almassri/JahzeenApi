using JahzeenApi.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Domain.Models
{
    public partial class Approvals : BaseModel
    {
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public ApplicationUser Account { get; set; }

        public string ApprovalUserName { get; set; }
        
        public int ActionType { get; set; }
    }
}
