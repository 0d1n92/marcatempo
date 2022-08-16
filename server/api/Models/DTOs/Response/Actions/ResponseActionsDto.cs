
using System;
namespace api.DTOs;

public class ActionDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Id { get; set; }
    public DateTime? Entry { get; set; }
    public DateTime? Exit { get; set; }
    public Boolean? IsPresent { get; set; }
}
