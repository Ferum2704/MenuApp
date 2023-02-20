using MediatR;
using UserService.Domain.IRepositories;
using UserService.Domain.Models;
using UserService.Proxies.ProxyInterfaces;

namespace UserService.Application.Commands
{
    public class LoginUserCommand:IRequest<Guid>
    {
        public User User { get; set; } = null!;
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Guid>
        {
            private readonly IUserCosmosRepository _repository;
            private readonly IOrderServiceProxy _orderServiceProxy;
            public LoginUserCommandHandler(IUserCosmosRepository repository, IOrderServiceProxy orderServiceProxy)
            {
                _repository = repository;
                _orderServiceProxy = orderServiceProxy;
            }

            public async Task<Guid> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                User? foundUser = await _repository.GetByPartitionKey(request.User.PhoneNumber);
                if (foundUser is null)
                {
                    request.User.Id = Guid.NewGuid();
                    User addedUser = await _repository.AddAsync(request.User);
                    return addedUser is null ? Guid.Empty : addedUser.Id;
                }
                await _orderServiceProxy.EnsureNoCurrentOrder(foundUser.Id);
                return foundUser.Id;
            }
        }
    }
}
