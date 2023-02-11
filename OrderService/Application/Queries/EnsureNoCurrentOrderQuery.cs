using MediatR;
using OrderService.Domain.IRepositories;

namespace OrderService.Application.Queries
{
    public class EnsureNoCurrentOrderQuery:IRequest
    {
        public Guid VisitorId { get; set; }
        public class EnsureNoCurrentOrderQueryHandler : IRequestHandler<EnsureNoCurrentOrderQuery>
        {
            private readonly IOrderRepository _repository;
            public EnsureNoCurrentOrderQueryHandler(IOrderRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(EnsureNoCurrentOrderQuery request, CancellationToken cancellationToken)
            {
                await _repository.DeleteOrderByVisitorId(request.VisitorId);
                return Unit.Value;
            }
        }
    }
}
