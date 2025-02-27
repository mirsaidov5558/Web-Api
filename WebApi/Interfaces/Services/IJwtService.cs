using WebApi.Models;

namespace WebApi.Interfaces.Services;

    public interface IJwtService
    {
        string GenerateToken(User user);
    }

