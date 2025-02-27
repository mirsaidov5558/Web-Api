using WebApi.Models;

namespace WebApi.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetFilteredProductsAsync(int? categoryId, string? productName, decimal? minPrice, decimal? maxPrice);
        Task AddAsync(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
