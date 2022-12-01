namespace MenuItemService.Domain.Models
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public int Weight { get; set; }
        public string Name { get; set; } = null!;
        public int CaloriesAmount { get; set; }
    }
}
