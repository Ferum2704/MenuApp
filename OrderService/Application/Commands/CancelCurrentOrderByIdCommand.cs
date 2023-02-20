using MediatR;
using OrderService.Domain.IRepositories;

namespace OrderService.Application.Commands
{
    public class CancelCurrentOrderByIdCommand:IRequest
    {
        public Guid Id { get; set; }
        public class CancelCurrentOrderByIdCommandHandler : IRequestHandler<CancelCurrentOrderByIdCommand>
        {
            private readonly IOrderRepository _repository;
            public CancelCurrentOrderByIdCommandHandler(IOrderRepository repository)
            {
                _repository = repository;
            }
            public async Task<Unit> Handle(CancelCurrentOrderByIdCommand request, CancellationToken cancellationToken)
            {
                await _repository.DeleteCurrentOrderById(request.Id);
                return Unit.Value;
            }
        }
    }
}
