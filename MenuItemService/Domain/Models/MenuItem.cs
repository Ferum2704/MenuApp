namespace MenuItemService.Domain.Models
{
    public class MenuItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
