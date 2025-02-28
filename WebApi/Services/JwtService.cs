using System.Security.Claims;
using System.Security.Cryptography;
using WebApi.Interfaces.Services;
using WebApi.Models;

namespace WebApi.Services
{
    public class JwtService : IJwtService
    {
        public readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encodimg.Utf8.GetBytes(_configuration["JWT: key"]));
            var creds = new SugningCredentials(key, SecurityAlgorithms.HmasSha256);
            var token = new JwtSecurityToken(
                null,
                null,
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
