namespace MenuItemService.Domain.Models
{
    public class CategoriedMenuItem
    {
        public Guid MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Priority { get; set; }
    }
}
