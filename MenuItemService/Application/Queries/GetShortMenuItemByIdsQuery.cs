using AutoMapper;
using MediatR;
using MenuItemService.Domain.IRepositories;
using MenuItemService.Presentation.ViewModels;

namespace MenuItemService.Application.Queries
{
    public class GetShortMenuItemByIdsQuery : IRequest<IEnumerable<ShortMenuItemViewModel>>
    {
        public IEnumerable<Guid> Ids;
        public class GetShortMenuItemByIdsQueryHandler : IRequestHandler<GetShortMenuItemByIdsQuery, IEnumerable<ShortMenuItemViewModel>>
        {
            private readonly IMenuItemRepository _repository;
            private readonly IMapper _mapper;
            public GetShortMenuItemByIdsQueryHandler(IMenuItemRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<IEnumerable<ShortMenuItemViewModel>> Handle(GetShortMenuItemByIdsQuery request, CancellationToken cancellationToken)
            {
                var menuItems = await _repository.GetByIdsAsync(request.Ids);
                return menuItems.Select(item => _mapper.Map<ShortMenuItemViewModel>(item)).ToList();
            }
        }
    }
}
