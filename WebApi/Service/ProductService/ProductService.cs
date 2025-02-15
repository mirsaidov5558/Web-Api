using WebApi.Models;

namespace WebApi.Service.ProductService
{
    public class ProductService : IProductService
    {
        public Task<List<Product>> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
