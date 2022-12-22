using Common.Interfaces;

namespace MenuItemService.Proxies.ProxyInterfaces
{
    public interface IOrderServiceProxy:IProxyService
    {
        public Task<IEnumerable<Guid>> GetMostPopularMenuItemsIds(int itemsNumber);
    }
}
