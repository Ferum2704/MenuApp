using OrderService.Presentation.ViewModels;

namespace OrderService.Proxies.ProxyInterfaces
{
    public interface IMenuItemServiceProxy
    {
        public Task<OrderedMenuItemViewModel> GetMenuItemDetailsById(Guid id);
        public Task<IEnumerable<OrderedMenuItemViewModel>> GetMenuItemDetailsByIds(IEnumerable<Guid> ids);
    }
}
