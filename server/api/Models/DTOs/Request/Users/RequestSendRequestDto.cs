using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class RequestSendRequestDto
    {
        [Required]
        public string Email { get; set; }

    }
}