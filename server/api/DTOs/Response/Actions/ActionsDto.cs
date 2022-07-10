
using System;
namespace api.DTOs;

public class ActionsDto
{
    public int Id { get; set; }
    public DateTime? Entry { get; set; }
    public DateTime? Exit { get; set; }
    public Boolean? IsPresent { get; set; }
}
