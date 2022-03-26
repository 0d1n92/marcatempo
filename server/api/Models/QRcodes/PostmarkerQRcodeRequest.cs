using System.ComponentModel.DataAnnotations;

namespace api.Models.QRcodes
{
    public class PostmarkerQRcodeRequest
    {
        [Required]
        public bool Exit { get; set; } = false;

        [Required]
        public int UserId { get; set; }

        [Required]
        public string QRtoken { get; set; }
    }
}
