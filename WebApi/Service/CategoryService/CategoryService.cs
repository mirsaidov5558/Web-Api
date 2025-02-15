using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly List<Category> _categories = new();

        public Task<bool> Create(string name, int? parentCategoryId)
        {
            var newCategory = new Category
            {
                Id = _categories.Count + 1,
                CategoryName = name,
                ParentCategoryId = (int)parentCategoryId
            };

            _categories.Add(newCategory);
            return Task.FromResult(true);

        }

        public Task<bool> Delete(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
                return Task.FromResult(false);

            _categories.Remove(category);

            var childCategories = _categories.Where(c => c.ParentCategoryId == id).ToList();
            foreach (var child in childCategories)
            {
                _categories.Remove(child);
            }

            return Task.FromResult(true);
        }

        public Task<List<Category>> GetAll()
        {
            return Task.FromResult(_categories);
        }

        public Task<List<Category>> GetChild(int parentCategoryId)
        {
            var childCategories = _categories.Where(c => c.ParentCategoryId == parentCategoryId).ToList();
            return Task.FromResult(childCategories);
        }

        public Task<bool> Update(int id, string newName, int? parentCategoryId)
        {
            throw new NotImplementedException();
        }

    }
}
