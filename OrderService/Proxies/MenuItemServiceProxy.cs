using Common;
using OrderService.Presentation.ViewModels;
using OrderService.Proxies.ProxyInterfaces;
using System.Collections.Generic;
using System.Configuration;

namespace OrderService.Proxies
{
    public class MenuItemServiceProxy : ProxyService, IMenuItemServiceProxy
    {
        private readonly IConfiguration _configuration;
        public MenuItemServiceProxy(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _configuration = configuration;
            _serviceUrl = _configuration.GetValue<string>("ServicesUrl:MenuItemServiceUrl");
        }

        public async Task<OrderedMenuItemViewModel> GetMenuItemDetailsById(Guid id)
        {
            return await GetFromJsonAsync<OrderedMenuItemViewModel>($"shortMenuItem/{id}");
        }
        public async Task<IEnumerable<OrderedMenuItemViewModel>> GetMenuItemDetailsByIds(IEnumerable<Guid> ids)
        {
            var response = await GetFromJsonAsync<IEnumerable<Guid>>("shortMenuItemsByIds", ids);
            var orderedMenuItems = await response.Content.ReadFromJsonAsync<IEnumerable<OrderedMenuItemViewModel>>();
            return orderedMenuItems;
        }
    }
}
