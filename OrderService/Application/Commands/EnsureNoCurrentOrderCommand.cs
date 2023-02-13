using MediatR;
using OrderService.Domain.IRepositories;

namespace OrderService.Application.Commands
{
    public class EnsureNoCurrentOrderCommand : IRequest
    {
        public Guid VisitorId { get; set; }
        public class EnsureNoCurrentOrderCommandHandler : IRequestHandler<EnsureNoCurrentOrderCommand>
        {
            private readonly IOrderRepository _repository;
            public EnsureNoCurrentOrderCommandHandler(IOrderRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(EnsureNoCurrentOrderCommand request, CancellationToken cancellationToken)
            {
                await _repository.DeleteOrderByVisitorId(request.VisitorId);
                return Unit.Value;
            }
        }
    }
}
