using Common.Interfaces;
using OrderService.Domain.Models;

namespace OrderService.Domain.IRepositories
{
    public interface IMenuItemOrderRepository:IRepository<MenuItemOrder>
    {
        public Task<Guid> DeleteMenuItemInOrderById(Guid id, Guid orderId);
    }
}
