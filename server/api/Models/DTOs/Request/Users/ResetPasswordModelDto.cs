using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.Request.Users
{
    public class ResetPasswordModelDto
    {
        [Required]
        [MinLength(6, ErrorMessage = "The password must contain at least 6 characters")]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d).{6,}$", ErrorMessage = "The password must contain at least 2 numbers and 4 characters")]
        public string Password { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "The password must contain at least 6 characters")]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d).{6,}$", ErrorMessage = "The password must contain at least 2 numbers and 4 characters")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^\S+$", ErrorMessage = "l'email non deve contenere spazi.")]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
