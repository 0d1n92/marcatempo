using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class RequestRegisterDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^\S+$", ErrorMessage = "lo usaraname non deve contenere spazi.")]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"^\S+$", ErrorMessage = "l'email non deve contenere spazi.")]
        public string Email { get; set; }
        [Required]
        public int RoleId  { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "The password must contain at least 6 characters")]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d).{6,}$", ErrorMessage = "The password must contain at least 2 numbers and 4 characters")]
        public string Password { get; set; }
    }
}