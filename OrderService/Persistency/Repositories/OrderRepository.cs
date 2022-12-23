using Common;
using Common.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.IRepositories;
using OrderService.Domain.Models;

namespace OrderService.Persistency.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(IDapperContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Guid>> GetMostPopularItemsId(int itemsNumber)
        {
            var query = "SELECT TOP " + itemsNumber.ToString() +" MenuItemId FROM MenuItemOrder GROUP BY MenuItemId ORDER BY SUM(Number) DESC";
            using (var connection = _context.CreateConnection())
            {
                IEnumerable<Guid> menuItemsIds = await connection.QueryAsync<Guid>(query, new {itemsNumber});
                return menuItemsIds;
            }
        }
    }
}
