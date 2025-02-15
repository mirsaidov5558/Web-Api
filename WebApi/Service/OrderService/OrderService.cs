using WebApi.Models;

namespace WebApi.Service.OrderService
{
    public class OrderService : IOrderService
    {
        public Task<bool> Create(string name, int? userId, DateTime createdAt, string status)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetChild(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(string newName, int? userId, DateTime createdAt, string status)
        {
            throw new NotImplementedException();
        }
    }
}
