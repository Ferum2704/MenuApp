using Common;
using Common.Interfaces;
using Dapper;
using MenuItemService.Domain.IRepositories;
using MenuItemService.Domain.Models;

namespace MenuItemService.Persistency.Repositories
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(IDapperContext context) : base(context) { }

        public async Task<IEnumerable<MenuItem>> GetByCategoryAsync(Guid categoryId)
        {
            var query = "SELECT * FROM MenuItem WHERE CategoryId = @categoryId";
            using (var connection = _context.CreateConnection())
            {
                var menuItems = await connection.QueryAsync<MenuItem>(query, new { categoryId });
                return menuItems;
            }
        }
    }
}
