using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories.Interface;

namespace WebApi.Repositories
{
    public class CategoryRepositories : ICategoryRepository
    {
        public readonly ApplicationDbContext _context;

        public CategoryRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Category>> GetAsyncAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
            
        public Task<List<Category>> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
