using Common.GenericRepositories;
using Common.Interfaces;
using Dapper;
using OrderService.Domain.IRepositories;
using OrderService.Domain.Models;

namespace OrderService.Persistency.Repositories
{
    public class MenuItemOrderDapperRepository : DapperRepository<MenuItemOrder>, IMenuItemOrderRepository
    {
        public MenuItemOrderDapperRepository(IDapperContext context) : base(context)
        {
        }

        public async Task<Guid> DeleteMenuItemInOrderById(Guid id, Guid orderId)
        {
            var query = "DELETE MenuItemOrder FROM MenuItemOrder INNER JOIN [Order]" +
                " ON MenuItemOrder.OrderId = [Order].Id WHERE MenuItemOrder.Id = @id AND [Order].Id = @orderId";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id, orderId });
                return id;
            }
        }
    }
}
