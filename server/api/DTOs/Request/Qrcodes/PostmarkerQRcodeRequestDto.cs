using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class PostmarkerQRcodeRequestDto
    {
        [Required]
        public bool Exit { get; set; } = false;
        [Required]
        public int UserId { get; set; }
        [Required]
        public string QRtoken { get; set; }
    }
}
