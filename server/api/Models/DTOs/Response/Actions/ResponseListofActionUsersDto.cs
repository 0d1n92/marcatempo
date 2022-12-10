using api.Model.Entity;
using System;
using System.Collections.Generic;

namespace api.DTOs
{
    public class ResponseListofActionUsersDto
    {
        public DateTime  Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Total { get; set; }
        public bool IsPresent { get; set; }
        public List<ActionDto> Actions { get; set; }
       
    }

}
