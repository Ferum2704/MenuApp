using MediatR;
using MenuItemService.Domain.IRepositories;
using MenuItemService.Domain.Models;

namespace MenuItemService.Application.Queries
{
    public class GetCategoriesQuery:IRequest<IEnumerable<Category>>
    {
        public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
        {
            private readonly ICategoryRepository _repository;
            public GetCategoriesQueryHandler(ICategoryRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetAllAsync();
            }
        }
    }
}
