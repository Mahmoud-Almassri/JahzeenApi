using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.SearchModels
{
    public partial class UserSearch : BaseSearch
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }

    }
}
