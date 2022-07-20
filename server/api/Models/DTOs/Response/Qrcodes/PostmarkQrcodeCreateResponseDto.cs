using System;

namespace api.DTOs
{
    public class PostmarkQrcodeCreateResponseDto
    {
        public bool Exit { get; set; } = false;

        public int UserName { get; set; }

        public Guid token { get; set; }
    }
}
