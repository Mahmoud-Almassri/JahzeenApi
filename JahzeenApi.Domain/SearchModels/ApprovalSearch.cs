using Domains.SearchModels;
using JahzeenApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Domain.SearchModels
{
    public class ApprovalSearch 
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public ApprovalStatus? Status { get; set; }
        public string Name { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

    }
}
