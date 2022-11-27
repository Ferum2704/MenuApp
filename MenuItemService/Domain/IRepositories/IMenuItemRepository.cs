using Common.Interfaces;
using MenuItemService.Domain.Models;

namespace MenuItemService.Domain.IRepositories
{
    public interface IMenuItemRepository:IRepository<MenuItem>
    {
        public Task<IEnumerable<MenuItem>> GetByCategoryAsync(Guid id);
    }
}
