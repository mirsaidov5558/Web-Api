using WebApi.Dto.CategoryDto;
using WebApi.Dto.CategoryDtos;

namespace WebApi.Interfaces.Services;
public interface ICategoryService
{
    Task<CategoryDto> GetByIdAsync(int id);
    Task<List<CategoryDto>> GetAllAsync();
    Task<List<CategoryDto>> GetSubcategoriesAsync(int parentId);
    Task<CategoryWithSubcategoriesDto> GetCategoryWithSubcaregoriesAsync(int id);
    Task<int> CreateAsync(CategoryCreateDto dto);
    Task<bool> UpdateAsync(int id, CategoryUpdatedto dto);
    Task<bool> DeleteAsync(int id);
    Task<List<CategoryTreeDto>> GetCategoryTreeAsync();
}

