using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Domain.DTO
{
    public class ApprovalDTO
    {
        public int AccountId { get; set; }
        public int ApprovalId { get; set; }
        public int ActionType { get; set; }
        public string Comments { get; set; }
    }
}
