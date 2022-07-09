namespace api.DTOs
{
    public class PostmarkQrcodeCreateResponseDto
    {
        public bool Exit { get; set; } = false;

        public int UserId { get; set; }

        public string QRtoken { get; set; }
    }
}
