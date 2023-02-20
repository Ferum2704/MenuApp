using Common.Interfaces;

namespace UserService.Proxies.ProxyInterfaces
{
    public interface IOrderServiceProxy
    {
        public Task EnsureNoCurrentOrder(Guid visitorId);
    }
}
