namespace api.DTOs
{
    public class GetListOperatorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public ActionsDto action { get; set; }

    }

}
