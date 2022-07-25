namespace api.DTOs
{
    public class ResponsUsersDto
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string QrCode { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string? Avatar { get; set; }

    }
}
