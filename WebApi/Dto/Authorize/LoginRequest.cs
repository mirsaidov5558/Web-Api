using System.ComponentModel.DataAnnotations;

namespace WebApi.Dto.Authorize
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Неправильный пароль")]
        public string Password { get; set; } = string.Empty;
    }
}
