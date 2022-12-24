
using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class ActionDto
    { 
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy HH:mm}")]
        public string Entry { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy HH:mm}")]
        public string Exit { get; set; }

    }

}
