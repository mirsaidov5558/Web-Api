using WebApi.Models;

namespace WebApi.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
        Task<List<User>> GetFilteredUsersAsync(string? email, string? name);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);


        Task<User?> GetByUsernameAsync(string username);
        Task<bool> ExistsAsync(string username);

    }
}
