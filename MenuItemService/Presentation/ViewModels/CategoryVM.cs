using MenuItemService.Domain.Models;

namespace MenuItemService.Presentation.ViewModels
{
    public class CategoryVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Priority { get; set; }
        public IEnumerable<ShortMenuItemVM> MenuItems { get; set; } = new List<ShortMenuItemVM>();
    }
}
