using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories.Interface;

namespace WebApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null) 
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<List<Category>> GetCategoriesWithSubcategoriesAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.Subcategories)
                .Where(c => c.Id == id)
                .ToListAsync();
        }

        public async Task<List<Category>> GetSubcategoriesAsync(int parentId)
        {
            return await _context.Categories.Where(c => c.ParentCategoryId == parentId).ToListAsync();
        }

        public async void Update(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
