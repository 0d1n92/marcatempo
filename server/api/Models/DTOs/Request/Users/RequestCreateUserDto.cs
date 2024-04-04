using api.Utilitis.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class RequestCreateUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^\S+$", ErrorMessage = "lo Username non deve contenere spazi.")]
        public string? Username { get; set; }
        [Required]
        public EnumRoles Role { get; set; } 
        [Required]
        [RegularExpression(@"^\S+$", ErrorMessage = "l'email non deve contenere spazi.")]
        public string Email { get; set; }
        public IFormFile? Avatar { get; set; } = null;
    }
}