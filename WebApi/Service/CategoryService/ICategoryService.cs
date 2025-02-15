using WebApi.Models;

namespace WebApi.Service.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<List<Category>> GetChild(int parentCategoryId);
        Task<bool> Delete(int id);
        Task<bool> Create(string name, int? parentCategoryId);
        Task<bool> Update(int id, string newName, int? parentCategoryId);
    }
}
