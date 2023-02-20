using AutoMapper;
using MediatR;
using OrderService.Domain.IRepositories;
using OrderService.Domain.Models;
using OrderService.Presentation.ViewModels;

namespace OrderService.Application.Commands
{
    public class AddItemToOrderCommand:IRequest<OrderedMenuItemViewModel>
    {
        public OrderedMenuItemViewModel Item { get; set; }
        public class AddItemToOrderCommandHandler : IRequestHandler<AddItemToOrderCommand, OrderedMenuItemViewModel>
        {
            private readonly IMenuItemOrderRepository _repository;
            private readonly IMapper _mapper;
            public AddItemToOrderCommandHandler(IMenuItemOrderRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<OrderedMenuItemViewModel> Handle(AddItemToOrderCommand request, CancellationToken cancellationToken)
            {
                request.Item.Id= Guid.NewGuid();
                request.Item.Number = 1;
                var menuItemToAdd = _mapper.Map<MenuItemOrder>(request.Item);
                var orderedmenuItem = await _repository.AddAsync(menuItemToAdd);
                if (orderedmenuItem != null)
                {
                    return request.Item;
                }
                return null;
            }
        }
    }
}
