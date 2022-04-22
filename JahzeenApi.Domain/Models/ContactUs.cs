using JahzeenApi.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace JahzeenApi.Domain.Models
{
    public partial class ContactUs : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}
