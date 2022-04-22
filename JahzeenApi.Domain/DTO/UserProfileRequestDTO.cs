using System;
using System.Collections.Generic;
using System.Text;

namespace JahzeenApi.Domain.DTO
{
    public class UserProfileRequestDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
