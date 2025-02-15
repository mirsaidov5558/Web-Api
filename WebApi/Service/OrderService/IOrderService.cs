using WebApi.Models;

namespace WebApi.Service.OrderService
{
    public interface IOrderService
    {
        Task<List<Order>> GetAll();
        Task<List<Order>> GetChild(int userId);
        Task<bool> Delete(int id);
        Task<bool> Create(string name, int? userId, DateTime createdAt, string status);
        Task<bool> Update(string newName, int? userId, DateTime createdAt, string status);
        
    }
}
