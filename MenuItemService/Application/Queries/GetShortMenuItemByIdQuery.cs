using AutoMapper;
using MediatR;
using MenuItemService.Domain.IRepositories;
using MenuItemService.Presentation.ViewModels;

namespace MenuItemService.Application.Queries
{
    public class GetShortMenuItemByIdQuery:IRequest<ShortMenuItemViewModel>
    {
        public Guid Id;
        public class GetShortMenuItemByIdQueryHandler : IRequestHandler<GetShortMenuItemByIdQuery, ShortMenuItemViewModel>
        {
            private readonly IMenuItemRepository _repository;
            private readonly IMapper _mapper;
            public GetShortMenuItemByIdQueryHandler(IMenuItemRepository repository, IMapper mapper)
            {
                _repository= repository;
                _mapper= mapper;
            }
            public async Task<ShortMenuItemViewModel> Handle(GetShortMenuItemByIdQuery request, CancellationToken cancellationToken)
            {
                var menuItem = await _repository.GetByIdAsync(request.Id);
                return _mapper.Map<ShortMenuItemViewModel>(menuItem);
            }
        }
    }
}
