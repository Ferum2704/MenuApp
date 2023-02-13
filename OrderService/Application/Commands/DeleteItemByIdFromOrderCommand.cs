using MediatR;
using OrderService.Domain.IRepositories;

namespace OrderService.Application.Commands
{
    public class DeleteItemByIdFromOrderCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public class DeleteItemByIdFromOrderQueryCommand : IRequestHandler<DeleteItemByIdFromOrderCommand, Guid>
        {
            private readonly IMenuItemOrderRepository _repository;
            public DeleteItemByIdFromOrderQueryCommand(IMenuItemOrderRepository repository)
            {
                _repository = repository;
            }

            public async Task<Guid> Handle(DeleteItemByIdFromOrderCommand request, CancellationToken cancellationToken)
            {
                return await _repository.DeleteMenuItemInOrderById(request.Id, request.OrderId);
            }
        }
    }
}
