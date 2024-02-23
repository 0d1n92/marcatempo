using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs;
    public class RequestActionDto
    {

    [DataType(DataType.DateTime)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
    public string Entry { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public string Exit { get; set; }

}

