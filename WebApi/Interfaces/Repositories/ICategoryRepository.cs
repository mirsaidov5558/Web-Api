using WebApi.Models;

namespace WebApi.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        Task<List<Category>> GetSubcategoriesAsync(int parentId);
        Task<List<Category>> GetCategoriesWithSubcategoriesAsync(int id);
        Task AddAsync(Category category);
        void Update(Category category);
        void Delete(Category category);
        Task<bool> ExistsAsync(int id);

    }
}
