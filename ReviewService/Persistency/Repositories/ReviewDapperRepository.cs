using Common.GenericRepositories;
using Common.Interfaces;
using Dapper;
using ReviewService.Domain.IRepositories;
using ReviewService.Domain.Models;

namespace ReviewService.Persistency.Repositories
{
    public class ReviewDapperRepository : DapperRepository<Review>, IReviewRepository
    {
        public ReviewDapperRepository(IDapperContext context) : base(context) { }

        public async Task<IEnumerable<Review>> GetReviewsByItemIdAsync(Guid itemId)
        {
            var query = "SELECT * FROM Review WHERE MenuItemId = @itemId";
            using (var connection = _context.CreateConnection())
            {
                var reviews = await connection.QueryAsync<Review>(query, new { itemId });
                return reviews;
            }
        }
    }
}
