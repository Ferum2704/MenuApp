using Common.Interfaces;
using ReviewService.Domain.Models;

namespace ReviewService.Domain.IRepositories
{
    public interface IReviewDapperRepository:IRepository<Review>
    {
        public Task<IEnumerable<Review>> GetReviewsByItemIdAsync(Guid itemId);
    }
}
