using MediatR;
using OrderService.Domain.IRepositories;

namespace OrderService.Application.Queries
{
    public class GetMostPopularMenuItemIdsQuery: IRequest<IEnumerable<Guid>>
    {
        public int ItemsNumber { get; set; }
        public class GetMostPopularMenuItemIdsQueryHandler : IRequestHandler<GetMostPopularMenuItemIdsQuery, IEnumerable<Guid>>
        {
            private readonly IOrderRepository _repository;
            public GetMostPopularMenuItemIdsQueryHandler(IOrderRepository repository)
            {
                _repository = repository;
            }
            public async Task<IEnumerable<Guid>> Handle(GetMostPopularMenuItemIdsQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetMostPopularItemsId(request.ItemsNumber);
            }
        }
    }
}
