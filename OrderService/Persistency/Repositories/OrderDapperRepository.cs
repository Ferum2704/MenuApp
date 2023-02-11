using Common.GenericRepositories;
using Common.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.IRepositories;
using OrderService.Domain.Models;

namespace OrderService.Persistency.Repositories
{
    public class OrderDapperRepository : DapperRepository<Order>, IOrderRepository
    {
        public OrderDapperRepository(IDapperContext context) : base(context)
        {
        }

        public async Task<Order> GetCurrentOrder(Guid visitorId)
        {
            var queryCurrentOrder = "SELECT * FROM [Order] WHERE VisitorId = @visitorId AND Status = 'Created'";
            var queryCurrentOrderItems = "SELECT * FROM MenuItemOrder WHERE OrderId = @orderId";
            using (var connection = _context.CreateConnection())
            {
                var currentOrder = await connection.QueryFirstOrDefaultAsync<Order>(queryCurrentOrder, new { visitorId });
                if (currentOrder != null)
                {
                    currentOrder.OrderedMenuItems = await connection.QueryAsync<MenuItemOrder>(queryCurrentOrderItems, new { orderId = currentOrder.Id });
                }
                return currentOrder;
            }
        }
        public async Task DeleteOrderByVisitorId(Guid visitorId)
        {
            var query = "DELETE FROM [Order] WHERE VisitorId = @visitorId";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { visitorId });
            }
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
