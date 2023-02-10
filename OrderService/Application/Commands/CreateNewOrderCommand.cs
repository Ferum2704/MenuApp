using AutoMapper;
using MediatR;
using OrderService.Domain.IRepositories;
using OrderService.Domain.Models;
using OrderService.Presentation.ViewModels;
using OrderService.Proxies.ProxyInterfaces;

namespace OrderService.Application.Commands
{
    public class CreateNewOrderCommand: IRequest<OrderViewModel>
    {
        public OrderToCreateInfoViewModel NewOrderInfo { get; set; } = null!;
        public class CreateNewOrderCommandHandler : IRequestHandler<CreateNewOrderCommand, OrderViewModel>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMenuItemOrderRepository _menuItemOrderRepository;
            private readonly IMapper _mapper;
            private readonly IMenuItemServiceProxy _proxy;
            public CreateNewOrderCommandHandler
                (IOrderRepository repository, IMapper mapper, IMenuItemOrderRepository menuItemOrderRepository, IMenuItemServiceProxy proxy)
            {
                _orderRepository= repository;
                _mapper= mapper;
                _menuItemOrderRepository= menuItemOrderRepository;
                _proxy = proxy;
            }
            public async Task<OrderViewModel> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
            {
                var menuItem = await _proxy.GetMenuItemDetailsById(request.NewOrderInfo.MenuItemId);
                Order newOrder = new Order
                {
                    Id = Guid.NewGuid(),
                    Status = "Created",
                    OrderDate = DateTime.Now,
                    Price = menuItem.Price,
                    VisitorId = request.NewOrderInfo.VisitorId,
                };
                await _orderRepository.AddAsync(newOrder);

                MenuItemOrder menuItemOrder = new MenuItemOrder
                {
                    Id = Guid.NewGuid(),
                    OrderId = newOrder.Id,
                    MenuItemId = request.NewOrderInfo.MenuItemId,
                    Number = 1
                };            
                await _menuItemOrderRepository.AddAsync(menuItemOrder);
                var orderedMenuItemVM = _mapper.Map<OrderedMenuItemViewModel>(menuItemOrder);
                orderedMenuItemVM.Price = menuItem.Price;
                orderedMenuItemVM.Name = menuItem.Name;
                OrderViewModel createdOrder = _mapper.Map<OrderViewModel>(newOrder);
                createdOrder.OrderedMenuItems = new List<OrderedMenuItemViewModel>() { orderedMenuItemVM };
                return createdOrder;
            }
        }
    }
}
