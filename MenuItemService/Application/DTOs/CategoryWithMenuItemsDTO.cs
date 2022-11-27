using MenuItemService.Domain.Models;

namespace MenuItemService.Application.DTOs
{
    public class CategoryWithMenuItemsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<MenuItem> MenuItems = new List<MenuItem>();
    }
}
