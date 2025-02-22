using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories.Interface;

namespace WebApi.Repositories
{
    public class UserRepositories : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetFilteredUsersAsync(string? email, string? name)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
