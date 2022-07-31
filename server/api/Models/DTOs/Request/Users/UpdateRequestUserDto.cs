
using api.Utilitis.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class UpdateRequestUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Username { get; set; }
        public EnumRoles? Role { get; set; }
        public string Email { get; set; }

        public IFormFile? Avatar { get; set; }
    }
}