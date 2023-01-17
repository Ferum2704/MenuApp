using Common;
using Common.Interfaces;
using Dapper;
using MenuItemService.Domain.IRepositories;
using MenuItemService.Domain.Models;

namespace MenuItemService.Persistency.Repositories
{
    public class MenuItemDapperRepository : DapperRepository<MenuItem>, IMenuItemDapperRepository
    {
        public MenuItemDapperRepository(IDapperContext context) : base(context) { }
        public async Task<IEnumerable<CategoriedMenuItem>> GetCategorizedMenuItems()
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

        public async Task<IEnumerable<MenuItem>> GetMostPopularMenuItems(IEnumerable<Guid> itemsGuids)
        {
            string concatenatedGuids = string.Empty;
            foreach (var guid in itemsGuids)
            {
                concatenatedGuids += "'" + guid.ToString() + "',";
            }
            concatenatedGuids = concatenatedGuids.Remove(concatenatedGuids.Length-1);
            string query = "SELECT * FROM MenuItem WHERE Id IN (" + concatenatedGuids +")";
            using (var connection = _context.CreateConnection())
            {
                IEnumerable<MenuItem> menuItems = await connection.QueryAsync<MenuItem>(query);
                return menuItems;
            }
        }
    }
}
