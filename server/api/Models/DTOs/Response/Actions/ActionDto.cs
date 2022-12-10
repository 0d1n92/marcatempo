using api.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class ActionDto
    {
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy HH:mm}")]
        public DateTime? Entry { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy HH:mm}")]
        public DateTime? Exit { get; set; }

    }

}
