using AutoMapper;
using MediatR;
using MenuItemService.Domain.IRepositories;
using MenuItemService.Domain.Models;
using MenuItemService.Presentation.ViewModels;
using Microsoft.Net.Http.Headers;

namespace MenuItemService.Application.Queries
{
    public class GetMostPopularMenuItemsQuery: IRequest<IEnumerable<ShortMenuItemViewModel>>
    {
        public int ItemsNumber { get; set; }
        public class GetMostPopularMenuItemsQueryHandler : IRequestHandler<GetMostPopularMenuItemsQuery, IEnumerable<ShortMenuItemViewModel>>
        {
            private readonly IMenuItemRepository _repository;
            private readonly IHttpClientFactory _httpClientFactory;
            private readonly IMapper _mapper;
            public GetMostPopularMenuItemsQueryHandler(IMenuItemRepository repository, 
                IHttpClientFactory httpClientFactory, IMapper mapper)
            {
                _repository = repository;
                _httpClientFactory = httpClientFactory;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ShortMenuItemViewModel>> Handle(GetMostPopularMenuItemsQuery request, CancellationToken cancellationToken)
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44314/api/Order/GetMostPopularMenuItems");
                var httpClient = _httpClientFactory.CreateClient();
                IEnumerable<Guid> response = await httpClient.Send(httpRequestMessage).Content.ReadFromJsonAsync<IEnumerable<Guid>>();
                IEnumerable<MenuItem> menuItems = await _repository.GetMostPopularMenuItems(response);
                return menuItems.Select(item => _mapper.Map<ShortMenuItemViewModel>(item));
            }
        }
    }
}
