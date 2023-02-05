using Common.GenericRepositories;
using Common.Interfaces;
using OrderService.Domain.IRepositories;
using OrderService.Domain.Models;

namespace OrderService.Persistency.Repositories
{
    public class MenuItemOrderDapperRepository : DapperRepository<MenuItemOrder>, IMenuItemOrderRepository
    {
        public MenuItemOrderDapperRepository(IDapperContext context) : base(context)
        {
        }
    }
}
