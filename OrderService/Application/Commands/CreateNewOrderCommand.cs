﻿using AutoMapper;
using MediatR;
using OrderService.Domain.IRepositories;
using OrderService.Domain.Models;
using OrderService.Presentation.ViewModels;

namespace OrderService.Application.Commands
{
    public class CreateNewOrderCommand: IRequest<OrderViewModel>
    {
        public OrderViewModel CreatedOrder { get; set; } = null!;
        public class CreateNewOrderCommandHandler : IRequestHandler<CreateNewOrderCommand, OrderViewModel>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMenuItemOrderRepository _menuItemOrderRepository;
            private readonly IMapper _mapper;
            public CreateNewOrderCommandHandler
                (IOrderRepository repository, IMapper mapper, IMenuItemOrderRepository menuItemOrderRepository)
            {
                _orderRepository= repository;
                _mapper= mapper;
                _menuItemOrderRepository= menuItemOrderRepository;
            }
            public async Task<OrderViewModel> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
            {
                request.CreatedOrder.Id = Guid.NewGuid();
                request.CreatedOrder.Status = "Created";
                Order createdOrder = _mapper.Map<Order>(request.CreatedOrder);
                await _orderRepository.AddAsync(createdOrder);

                var orderedMenuItems = createdOrder.OrderedMenuItems.Select(item => { item.OrderId = createdOrder.Id; return item; });
                await _menuItemOrderRepository.AddRange(orderedMenuItems);
                return request.CreatedOrder;
            }
        }
    }
}