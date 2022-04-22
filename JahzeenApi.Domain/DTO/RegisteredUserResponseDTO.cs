using System;

namespace JahzeenApi.Domain.DTO
{
    public class RegisteredUserResponseDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
