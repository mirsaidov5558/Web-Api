using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories.Interface;

namespace WebApi.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<OrderItem>> GetAllAsync()
        {
            return await _context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Product)
                .ToListAsync();
        }

        public async Task<OrderItem> GetByIdAsync(int id)
        {
            return await _context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Product)
                .FirstOrDefaultAsync(oi => oi.Id == id);
        }

        public async Task<List<OrderItem>> GetFilteredOrderItemAync(int? orderId, int? productId, decimal? minPrice, decimal? maxPrice)
        {
            var query = _context.OrderItems.AsQueryable();

            if (orderId.HasValue)
                query = query.Where(oi => oi.OrderId == orderId.Value);
            if (productId.HasValue)
                query = query.Where(oi => oi.ProductId == productId.Value);
            if (minPrice.HasValue)
                query = query.Where(oi => oi.TotalPrice >= minPrice.Value);
            if (maxPrice.HasValue)
                query = query.Where(oi => oi.TotalPrice <= maxPrice.Value);

            return await query
                .Include(oi => oi.Order)
                .Include(oi => oi.Product)
                .ToListAsync();
        }

        public async Task Update(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();
        }
    }
}
