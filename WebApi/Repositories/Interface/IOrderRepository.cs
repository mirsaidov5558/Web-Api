using WebApi.Models;

namespace WebApi.Repositories.Interface
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int id);
        Task<List<Order>> GetAllAsync();
        Task<List<Order>> GetFilteredOrdersAsync(int? userId, string status);
        Task AddAsync(Order order);
        void Update(Order order);
        void Delete(Order order);
    }
}
