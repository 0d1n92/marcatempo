using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class RequestSendRequestDto
    {
        [Required]
        [RegularExpression(@"^\S+$", ErrorMessage = "l'email non deve contenere spazi.")]
        public string Email { get; set; }

    }
}