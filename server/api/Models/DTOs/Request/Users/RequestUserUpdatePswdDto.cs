using System.ComponentModel.DataAnnotations;
namespace api.Models.DTOs.Request.Users
{
    public class RequestUserUpdatePswdDto
    {

        [Required]
        [MinLength(6, ErrorMessage = "The password must contain at least 6 characters")]
        [RegularExpression(@"^(?=(.*\d){2}).{6,}$", ErrorMessage = "The password must contain at least two number")]
        public string Password { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "The password must contain at least 6 characters")]
        [RegularExpression(@"^(?=(.*\d){2}).{6,}$", ErrorMessage = "The password must contain at least two number")]
        public string ConfirmPassword { get; set; }

       
    }
}
