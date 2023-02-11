using Common;
using System.Configuration;
using UserService.Proxies.ProxyInterfaces;

namespace UserService.Proxies
{
    public class OrderServiceProxy : ProxyService, IOrderServiceProxy
    {
        private readonly IConfiguration _configuration;
        public OrderServiceProxy(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _configuration = configuration;
            _serviceUrl = _configuration.GetValue<string>("ServicesUrl:OrderServiceUrl");
        }

        public async Task EnsureNoCurrentOrder(Guid visitorId)
        {
            await DeleteAsync($"currentOrder/{visitorId}");
        }
    }
}
