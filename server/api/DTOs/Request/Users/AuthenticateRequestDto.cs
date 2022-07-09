using System.ComponentModel.DataAnnotations;

namespace api.Response
{
    public class AuthenticateRequestDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}