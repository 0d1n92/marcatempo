using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace api.Model.Entity
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
        public virtual Role Role { get; set; }
        public virtual QRcode QRCode { get; set; }
        public virtual ICollection<Action> Activities { get; set; }
        public virtual ICollection<UserMeta> UserMetas { get; set; }

    }
}
