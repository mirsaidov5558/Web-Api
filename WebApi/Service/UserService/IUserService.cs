using WebApi.Models;

namespace WebApi.Service.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();

    }
}
