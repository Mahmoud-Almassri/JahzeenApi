using JahzeenApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JahzeenApi.Domain.Models.Common
{
    public class BaseModel
    {
        public int Id { get; set; }
        public BaseStatus? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedById { get; set; } 
        public ApplicationUser CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedById { get; set; }
        public ApplicationUser ModifiedBy { get; set; }
    }
}
