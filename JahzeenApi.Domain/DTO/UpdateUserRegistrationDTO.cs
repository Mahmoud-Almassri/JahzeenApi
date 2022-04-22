using System;
using System.Collections.Generic;
using System.Text;

namespace JahzeenApi.Domain.DTO
{
    public partial class UpdateUserRegistrationDTO
    {
        public int ApplicationUserId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
