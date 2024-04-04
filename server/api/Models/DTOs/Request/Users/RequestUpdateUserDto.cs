
using api.Utilitis.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class RequestUpdateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [RegularExpression(@"^\S+$", ErrorMessage = "lo usarname non deve contenere spazi.")]
        public string Username { get; set; }
        public EnumRoles? Role { get; set; }
        [RegularExpression(@"^\S+$", ErrorMessage = "l'email non deve contenere spazi.")]
        public string Email { get; set; }
        public bool deleteAvatar { get; set; }
        public IFormFile? Avatar { get; set; }
    }
}