﻿using api.Utilitis.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class CreateRequestUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public EnumRoles Role { get; set; }
        [Required]
        public string Email { get; set; }
        public IFormFile? Avatar { get; set; } = null;
    }
}