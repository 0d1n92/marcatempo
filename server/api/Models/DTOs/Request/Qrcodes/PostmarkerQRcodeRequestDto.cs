using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class PostmarkerQRcodeRequestDto
    {
        [Required]
        public bool Exit { get; set; } = false;

        [Required]
        public Guid token { get; set; }
    }
}
