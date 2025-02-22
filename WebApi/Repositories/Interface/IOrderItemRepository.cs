using WebApi.Models;

namespace WebApi.Repositories.Interface
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> GetByIdAsync(int id);
        Task<List<OrderItem>> GetAllAsync();
        Task<List<OrderItem>> GetFilteredOrderItemAync(int? orderId, int productId, decimal totalPrice);
        Task AddAsync(OrderItem orderItem);
        void Update(OrderItem orderItem);
        void Delete(OrderItem orderItem);
    }
}
