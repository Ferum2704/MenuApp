using Common;
using Common.Interfaces;
using MenuItemService.Domain.IRepositories;
using MenuItemService.Domain.Models;

namespace MenuItemService.Persistency.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDapperContext context) : base(context)
        {
        }
    }
}
