using MediatR;
using MenuItemService.Domain.IRepositories;
using MenuItemService.Domain.Models;

namespace MenuItemService.Application.Queries
{
    public class GetAllMenuItemsQuery:IRequest<IEnumerable<MenuItem>>
    {
        public class GetAllMenuItemsQueryHandler:IRequestHandler<GetAllMenuItemsQuery, IEnumerable<MenuItem>>
        {
            private readonly IMenuItemRepository _repository;
            public GetAllMenuItemsQueryHandler(IMenuItemRepository repository)
            {
                _repository = repository;
            }
            public async Task<IEnumerable<MenuItem>> Handle(GetAllMenuItemsQuery query, CancellationToken cancellationToken)
            {
                return await _repository.GetAll();
            }
        }
    }
}
