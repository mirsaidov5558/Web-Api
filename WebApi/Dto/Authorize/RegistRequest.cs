using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Dto.Authorize
{
    public class RegistRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set;} = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "Пароль должен содержать минимум 6 символов.")]
        public string Password { get; set; } = string.Empty;

    }
}
