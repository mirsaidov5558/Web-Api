using WebApi.Models;

namespace WebApi.Repositories.Interface
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> GetByIdAsync(int id);
        Task<List<OrderItem>> GetAllAsync();
        Task CreateAsync(List<OrderItem> orderItems);
        Task<List<OrderItem>> GetFilteredOrderItemAync(int? orderId, int? productId, decimal? minPrice, decimal? maxPrice);
        Task AddAsync(OrderItem orderItem);
        Task Update(OrderItem orderItem);
        Task Delete(int id);
    }
}
