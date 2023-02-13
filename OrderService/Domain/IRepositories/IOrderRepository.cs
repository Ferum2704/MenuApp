using Common.Interfaces;
using OrderService.Domain.Models;

namespace OrderService.Domain.IRepositories
{
    public interface IOrderRepository:IRepository<Order>
    {
        public Task<IEnumerable<Guid>> GetMostPopularItemsId(int itemsNumber);
        public Task<Order> GetCurrentOrder(Guid visitorId);
        public Task DeleteOrderByVisitorId(Guid visitorId);
        public Task DeleteCurrentOrderById (Guid id);
    }
}
