using api.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class ResponseListofActionUsersDto
    {
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]

        public int Index { get; set; }
        public string  Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Total { get; set; }
        public bool IsPresent { get; set; }
        public List<ActionDto> Actions { get; set; }
    }

}
