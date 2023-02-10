using AutoMapper;
using MediatR;
using OrderService.Domain.IRepositories;
using OrderService.Domain.Models;
using OrderService.Presentation.ViewModels;
using OrderService.Proxies.ProxyInterfaces;

namespace OrderService.Application.Queries
{
    public class GetCurrentOrderQuery:IRequest<OrderViewModel>
    {
        public Guid VisitorId { get; set; }
        public class GetCurrentOrderQueryHandler : IRequestHandler<GetCurrentOrderQuery, OrderViewModel>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;
            private readonly IMenuItemServiceProxy _proxy;
            public GetCurrentOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper, IMenuItemServiceProxy proxy)
            {
                _orderRepository= orderRepository;
                _mapper= mapper;
                _proxy= proxy;
            }
            public async Task<OrderViewModel> Handle(GetCurrentOrderQuery request, CancellationToken cancellationToken)
            {
                Order currentOrder = await _orderRepository.GetCurrentOrder(request.VisitorId);
                if (currentOrder != null)
                {
                    OrderViewModel currentOrderVM = _mapper.Map<OrderViewModel>(currentOrder);
                    var menuItems = await _proxy.GetMenuItemDetailsByIds(currentOrder.OrderedMenuItems.Select(item => item.MenuItemId).ToList());
                    currentOrderVM.OrderedMenuItems = currentOrderVM.OrderedMenuItems.Zip(menuItems, (a, b) => 
                    {
                        a.Name = b.Name;
                        a.Price = b.Price;
                        return a;
                    });
                    return currentOrderVM;
                }
                return null;
            }
        }
    }
}
