
namespace api.Models.Data
{
    public class SmtpConfig
    {
        

        public string Server { get; set; }
        public string UserName { get; set; }
        public int Port { get; set; }
        public string SenderEmail { get; set; }

        public string SenderName { get; set; }
        public string Password { get; set; }

  
    }
}
