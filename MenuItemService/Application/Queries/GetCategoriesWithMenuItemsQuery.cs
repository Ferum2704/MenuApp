using MediatR;
using MenuItemService.Domain.IRepositories;
using MenuItemService.Domain.Models;
using MenuItemService.Presentation.ViewModels;

namespace MenuItemService.Application.Queries
{
    public class GetCategoriesWithMenuItemsQuery:IRequest<IEnumerable<CategoryVM>>
    {
        public class GetCategoriesWithMenuItemsQueryHandler : IRequestHandler<GetCategoriesWithMenuItemsQuery, IEnumerable<CategoryVM>>
        {
            private readonly IMenuItemRepository _repository;
            public GetCategoriesWithMenuItemsQueryHandler(IMenuItemRepository repository)
            {
                _repository = repository;
            }
            public async Task<IEnumerable<CategoryVM>> Handle(GetCategoriesWithMenuItemsQuery query, CancellationToken cancellationToken)
            {
                var categoriedMenuItems = await _repository.GetCategoriedMenuItems();
                return categoriedMenuItems.GroupBy(i => new { i.CategoryId, i.CategoryName, i.Priority }).Select(g => new CategoryVM()
                {
                    Id = g.Key.CategoryId,
                    Name = g.Key.CategoryName,
                    Priority = g.Key.Priority,
                    MenuItems = g.Select(i => new ShortMenuItemVM() { Id = i.MenuItemId, Name = i.MenuItemName, Price = i.Price })
                });
            }
        }
    }
}
