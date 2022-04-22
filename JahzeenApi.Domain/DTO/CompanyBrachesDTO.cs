using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Domain.DTO
{
    public class CompanyBrachesDTO : BaseModelDTO
    {
        public string CompanyId { get; set; }
        public string BranchName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Area { get; set; }
    }
}
