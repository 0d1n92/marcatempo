using System.ComponentModel.DataAnnotations;

namespace api.Response
{
    public class RegisterRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        public int RoleId = 2;
        [Required]
        public string Password { get; set; }
    }
}