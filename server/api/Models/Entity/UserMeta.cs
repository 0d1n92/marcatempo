﻿
namespace api.Model.Entity
{
    public class UserMeta
    {
        public int Id { get; set; }
        public string Metalabel { get; set; }
        public string Value { get; set; }
        public int? UserId { get; set; }
        public User User{ get; set; }
    }
}
