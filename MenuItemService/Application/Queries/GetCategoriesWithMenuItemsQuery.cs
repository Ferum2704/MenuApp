using MediatR;
using MenuItemService.Domain.IRepositories;
using MenuItemService.Domain.Models;
using MenuItemService.Presentation.ViewModels;

namespace MenuItemService.Application.Queries
{
    public class GetCategoriesWithMenuItemsQuery:IRequest<IEnumerable<CategoryViewModel>>
    {
        public class GetCategoriesWithMenuItemsQueryHandler : IRequestHandler<GetCategoriesWithMenuItemsQuery, IEnumerable<CategoryViewModel>>
        {
            private readonly IMenuItemDapperRepository _repository;
            public GetCategoriesWithMenuItemsQueryHandler(IMenuItemDapperRepository repository)
            {
                _repository = repository;
            }
            public async Task<IEnumerable<CategoryViewModel>> Handle(GetCategoriesWithMenuItemsQuery query, CancellationToken cancellationToken)
            {
                var categorizedMenuItems = await _repository.GetCategorizedMenuItems();
                return categorizedMenuItems.GroupBy(i => new { i.CategoryId, i.CategoryName, i.Priority }).Select(g => new CategoryViewModel()
                {
                    Id = g.Key.CategoryId,
                    Name = g.Key.CategoryName,
                    Priority = g.Key.Priority,
                    MenuItems = g.Select(i => new ShortMenuItemViewModel() { Id = i.MenuItemId, Name = i.MenuItemName, Price = i.Price })
                });
            }
        }
    }
}
