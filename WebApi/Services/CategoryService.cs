using WebApi.Dto.CategoryDto;
using WebApi.Dto.CategoryDtos;
using WebApi.Exceptions;
using WebApi.Interfaces.Repositories;
using WebApi.Interfaces.Services;
using WebApi.Models;
using WebApi.Repositories.Interface;

namespace WebApi.Service;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<int> CreateAsync(CategoryCreateDto dto)
    {
        int? parentId = dto.ParentCategoryId > 0 ? dto.ParentCategoryId : null;

        if (parentId.HasValue)
        {
            var parentExists = await _categoryRepository.ExistsAsync(parentId.Value);
            if (!parentExists)
            {
                throw new Exception($"Родительская категория ID {parentId} не найдена.");
            }
        }

        var category = new Category
        {
            CategoryName = dto.Name,
            ParentCategoryId = parentId.Value,
        };
        await _categoryRepository.AddAsync(category);
        return category.Id;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category != null)
            throw new Exception($"Категория с ID {id} не найдена.");

        _categoryRepository.Delete(category);
        return true;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return categories.Select(c => new CategoryDto {Id = c.Id, Name = c.CategoryName, ParentCategoryId = c.ParentCategoryId } ) .ToList();
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
            throw new NotFoundException($"Категория с ID {id} не найдена.");
        return new CategoryDto { Id = category.Id, Name = category.CategoryName, ParentCategoryId = category.ParentCategoryId };
    }

    public async Task<List<CategoryTreeDto>> GetCategoryTreeAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        var categoryLookup = categories.ToLookup(c => c.ParentCategoryId);

        List<CategoryTreeDto> BuildTree(int? parentId)
        {
            return categoryLookup[parentId]
                .Select(c => new CategoryTreeDto
                {
                    Id = c.Id,
                    Name = c.CategoryName,
                    Subcategories = BuildTree(c.Id)
                }).ToList();
        }
        return BuildTree(null);
    }

    public async Task<CategoryWithSubcategoriesDto> GetCategoryWithSubcaregoriesAsync(int id)
    {
        var category = await _categoryRepository.GetCategoriesWithSubcategoriesAsync(id);
        if (category == null)
            throw new NotFoundException($"Категория с ID {id} не найдена.");

        return new CategoryWithSubcategoriesDto
        {
            Id = category.Id,
            Name = category.
        };
    }

    public async Task<List<CategoryDto>> GetSubcategoriesAsync(int parentId)
    {
        var subcategories = await _categoryRepository.GetSubcategoriesAsync(parentId);
        return subcategories.Select(c => new CategoryDto { Id = c.Id, Name = c.CategoryName, ParentCategoryId = c.ParentCategoryId }).ToList();
    }

    public async Task<bool> UpdateAsync(int id, CategoryUpdatedto dto)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
            throw new NotFoundException($"Категория с ID {id} не найдена.");
        category.CategoryName = dto.Name;
        category.ParentCategoryId = (int)dto.ParentCategoryId;
        _categoryRepository.Update(category);
        return true;
    }
}

