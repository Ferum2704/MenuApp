namespace MenuItemService.Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Priority { get; set; }
    }
}
