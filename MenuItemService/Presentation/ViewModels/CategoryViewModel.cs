using MenuItemService.Domain.Models;

namespace MenuItemService.Presentation.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Priority { get; set; }
        public IEnumerable<ShortMenuItemViewModel> MenuItems { get; set; } = new List<ShortMenuItemViewModel>();
    }
}
