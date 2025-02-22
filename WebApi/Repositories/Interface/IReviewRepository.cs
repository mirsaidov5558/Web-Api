using WebApi.Models;

namespace WebApi.Repositories.Interface
{
    public interface IReviewRepository
    {
        Task<Review> GetByIdAsync(int id);
        Task<List<Review>> GetAllAsync();
        Task<List<Review>> GetFilteredReviewsAsync(int? userId, int? productId, string comment);
        Task AddAsync(Review review);
        void Update(Review review);
        void Delete(Review review);
        

    }
}
