using Common;
using MenuItemService.Application.Queries;
using MenuItemService.Proxies.ProxyInterfaces;

namespace MenuItemService.Proxies
{
    public class OrderServiceProxy : ProxyService, IOrderServiceProxy
    {
        private readonly IConfiguration _configuration;
        public OrderServiceProxy(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _configuration = configuration;
            _serviceUrl = _configuration.GetValue<string>("ServicesUrl:OrderServiceUrl");
        }
        public async Task<IEnumerable<Guid>> GetMostPopularMenuItemsIds(int itemsNumber)
        {
            return await GetFromJsonAsync<IEnumerable<Guid>>($"mostPopularItemsIds/{itemsNumber}");
        }
    }
}
