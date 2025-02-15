using WebApi.Models;

namespace WebApi.Service.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<List<Product>> GetProductById(int id);
    }
}
