using api.Model.Entity;
namespace api.Interface
{
    public interface IJwtUtils
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
        public string GenerateResetPasswordToken(User user);
        public bool ValidateResetPasswordToken(string token, User user);
       
     }
}
