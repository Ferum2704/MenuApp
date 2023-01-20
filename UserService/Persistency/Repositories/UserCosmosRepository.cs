using Common.GenericRepositories;
using Common.Interfaces;
using UserService.Domain.IRepositories;
using UserService.Domain.Models;

namespace UserService.Persistency.Repositories
{
    public class UserCosmosRepository : CosmosRepository<User>, IUserCosmosRepository
    {
        public UserCosmosRepository(ICosmosHelper cosmosHelper) : base(cosmosHelper)
        {
        }
    }
}
