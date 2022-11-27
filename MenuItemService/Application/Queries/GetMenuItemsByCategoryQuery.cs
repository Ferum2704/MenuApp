using MediatR;
using MenuItemService.Domain.IRepositories;
using MenuItemService.Domain.Models;

namespace MenuItemService.Application.Queries
{
    public class GetMenuItemsByCategoryQuery:IRequest<IEnumerable<MenuItem>>
    {
        public Guid CategoryId {get; set;}
        public class GetMenuItemsByCategoryQueryHandler : IRequestHandler<GetMenuItemsByCategoryQuery, IEnumerable<MenuItem>>
        {
            private readonly IMenuItemRepository _repository;
            public GetMenuItemsByCategoryQueryHandler(IMenuItemRepository repository)
            {
                _repository = repository;
            }
            public async Task<IEnumerable<MenuItem>> Handle(GetMenuItemsByCategoryQuery query, CancellationToken cancellationToken)
            {
                return await _repository.GetByCategoryAsync(query.Id);
            }
        }
    }
}
