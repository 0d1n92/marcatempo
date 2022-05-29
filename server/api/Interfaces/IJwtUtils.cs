using api.Model.Entity;
namespace api.Interface
{
    public interface IJwtUtils
    {
        public string GenerateToken(User user);
        public string QRGenerateToken(QRcode qrcode);
        public string QRSeedGenerateToken(int id);
        public int? ValidateToken(string token);
    }
}
