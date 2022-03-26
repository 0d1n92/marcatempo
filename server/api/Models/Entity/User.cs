using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace api.Response
{
    enum EnumRoles { Administrator = 1, Operator = 2 }
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Token { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public QRcode QRCode { get; set; }
        public ICollection<Activity> Activities { get; set; }

    }
}
