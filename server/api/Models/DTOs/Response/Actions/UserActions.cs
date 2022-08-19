using api.Model.Entity;
using System;
using System.Collections.Generic;

namespace api.DTOs
{
    public class UserActions
    {
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Model.Entity.Action> Actions { get; set; }
    }
}
