using Common.Interfaces;
using OrderService.Domain.Models;

namespace OrderService.Domain.IRepositories
{
    public interface IOrderRepository:IRepository<Order>
    {
        public Task<IEnumerable<Guid>> GetMostPopularItemsId();
    }
}
