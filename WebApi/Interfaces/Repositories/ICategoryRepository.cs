using WebApi.Models;

namespace WebApi.Interfaces.Repositories;
public interface ICategoryRepository
{
    Task<Category> GetByIdAsync(int id);
    Task<List<Category>> GetAllAsync();
    Task<List<Category>> GetSubcategoriesAsync(int parentId);
    Task<List<Category>> GetCategoriesWithSubcategoriesAsync(int id);
    Task AddAsync(Category category);
    Task Update(Category category);
    Task Delete(int id);
    Task<bool> ExistsAsync(int id);
    void Delete(Category? category);
}

