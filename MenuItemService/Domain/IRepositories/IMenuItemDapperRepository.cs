using Common.Interfaces;
using MenuItemService.Domain.Models;

namespace MenuItemService.Domain.IRepositories
{
    public interface IMenuItemDapperRepository:IRepository<MenuItem>
    {
        public Task<IEnumerable<CategoriedMenuItem>> GetCategorizedMenuItems();
        public Task<IEnumerable<MenuItem>> GetMostPopularMenuItems(IEnumerable<Guid> itemsGuids); 
    }
}
