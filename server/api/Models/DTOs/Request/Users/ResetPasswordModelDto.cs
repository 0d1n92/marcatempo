using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.Request.Users
{
    public class ResetPasswordModelDto
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
