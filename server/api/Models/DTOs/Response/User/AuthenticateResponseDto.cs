
using System.Collections.Generic;

namespace api.DTOs
{
    public class AuthenticateResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Token { get; set; }
        public string Avatar { get; set; }
        public List<UserMetaDto> meta { get; set; }

    }
}