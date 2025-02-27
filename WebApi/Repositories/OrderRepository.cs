using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories.Interface;

namespace WebApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null) 
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.Include(o => o.OrderItems).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Order>> GetFilteredOrdersAsync(int? userId, string? status)
        {
            var query = _context.Orders.AsQueryable();

            if (userId.HasValue)
                query = query.Where(o => o.UserId == userId.Value);

            if (!string.IsNullOrEmpty(status))
                query = query.Where(o => o.Status == status);

            return await query.Include(o => o.OrderItems).ToListAsync();
        }

        public async Task Update(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int orderId, string status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.Status = status;
                await _context.SaveChangesAsync();
            }
        }
    }
}
