using System;
using System.ComponentModel.DataAnnotations;

namespace PBK_dita.Models
{
    public record LoginModel
    {
        [Required]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
        public string Email { get; init; }
        [Required]
        public string Password { get; init; }

        public string? ReturnUrl { get; set; }
    }
}