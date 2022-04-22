using System;
using System.Collections.Generic;
using System.Text;

namespace JahzeenApi.Domain.DTO
{
    public class ExternalAuthDTO
    {
        public string Provider { get; set; }
        public string IdToken { get; set; }
    }
}
