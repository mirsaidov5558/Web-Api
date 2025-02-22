using WebApi.Models;

namespace WebApi.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetFilteredProductsAsync(int? cattegoryId, string productName, decimal price);
        Task AddAsync(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
