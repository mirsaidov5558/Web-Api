using WebApi.Dto.OrderItemDto;
using WebApi.Enums;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Repositories.Interface;
using WebApi.Service.OrderService;

namespace WebApi.Service
{
    public class OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository) : IOrderService
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IOrderItemRepository _orderItemRepository = orderItemRepository;

        public Task<bool> Create(string name, int? userId, DateTime createdAt, string status)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateAsync(int userId, Status status, List<OrderItemRequestDtos> orderItemRequest)
        {
            Order order = new()
            {
                UserId = userId,
                Status = status,
            };
            await _orderRepository.AddAsync(order);
            await _orderItemRepository.CreateAsync(orderItemRequest.Select(o => new OrderItem
            {
                OrderId = userId,
                ProductId = o.ProductId,
                Quantity = o.Quantity,
                TotalPrice = o.TotalPrice,
            }).ToList());
            return true;
        }

        public Task<bool> Delete(int id)
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

        public Task<List<Order>> GetListAsync(int userId)
        {
            if (userId <= 0) throw
        }

        public Task<bool> Update(string newName, int? userId, DateTime createdAt, string status)
        {
            throw new NotImplementedException();
        }
    }
}
