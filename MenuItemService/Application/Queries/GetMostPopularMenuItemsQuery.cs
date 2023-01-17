using AutoMapper;
using MediatR;
using MenuItemService.Domain.IRepositories;
using MenuItemService.Domain.Models;
using MenuItemService.Presentation.ViewModels;
using MenuItemService.Proxies.ProxyInterfaces;
using Microsoft.Net.Http.Headers;

namespace MenuItemService.Application.Queries
{
    public class GetMostPopularMenuItemsQuery: IRequest<IEnumerable<ShortMenuItemViewModel>>
    {
        public int ItemsNumber { get; set; }
        public class GetMostPopularMenuItemsQueryHandler : IRequestHandler<GetMostPopularMenuItemsQuery, IEnumerable<ShortMenuItemViewModel>>
        {
            private readonly IMenuItemRepository _repository;
            private readonly IOrderServiceProxy _proxy;
            private readonly IMapper _mapper;
            public GetMostPopularMenuItemsQueryHandler(IMenuItemRepository repository, 
                IOrderServiceProxy proxy, IMapper mapper)
            {
                _repository = repository;
                _proxy = proxy;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ShortMenuItemViewModel>> Handle(GetMostPopularMenuItemsQuery request, CancellationToken cancellationToken)
            {
                var response = await _proxy.GetMostPopularMenuItemsIds(request.ItemsNumber);
                IEnumerable<MenuItem> menuItems = await _repository.GetMostPopularMenuItems(response);
                return menuItems.Select(item => _mapper.Map<ShortMenuItemViewModel>(item));
            }
        }
    }
}
