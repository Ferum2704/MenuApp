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
        public async Task<IEnumerable<CategoriedMenuItem>> GetCategoriedMenuItems()
        {
            string query = "SELECT MenuItem.Id AS MenuItemId," +
                " MenuItem.Name AS MenuItemName, Price, PhotoName, Category.Id AS CategoryId," +
                " Category.Name AS CategoryName, Priority FROM MenuItem INNER JOIN Category " +
                "ON MenuItem.CategoryId = Category.Id";
            using (var connection = _context.CreateConnection())
            {
                IEnumerable<CategoriedMenuItem> categoriedMenuItems = await connection.QueryAsync<CategoriedMenuItem>(query);
                return categoriedMenuItems;
            }
        }
    }
}
