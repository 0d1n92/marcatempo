using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class RequestPostmarkerQRcodeDto
    {
        [Required]
        public bool Exit { get; set; } = false;

        [Required]
        public Guid Token { get; set; }
    }
}
