using WebApi.Enums;
using WebApi.Interfaces.Services;

namespace WebApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthService _authService;
        public Task<string?> AuthenticateAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterAsync(string email, string password, Role role, string? firstName, string? lastName)
        {
            throw new NotImplementedException();
        }
    }
}
