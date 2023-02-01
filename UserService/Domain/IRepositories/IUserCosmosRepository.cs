using Common.Interfaces;
using UserService.Domain.Models;

namespace UserService.Domain.IRepositories
{
    public interface IUserCosmosRepository:ICosmosRepository<User>
    {
    }
}
