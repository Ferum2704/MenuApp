using Common.Interfaces;
using ReviewService.Domain.Models;

namespace ReviewService.Domain.IRepositories
{
    public interface IReviewRepository:IRepository<Review>
    {
        public Task<IEnumerable<Review>> GetReviewsByItemId(Guid itemId);
    }
}
