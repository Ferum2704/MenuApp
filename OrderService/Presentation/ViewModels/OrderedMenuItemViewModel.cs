namespace OrderService.Presentation.ViewModels
{
    public class OrderedMenuItemViewModel
    {
        public Guid Id { get; set; }
        public Guid MenuItemId { get; set; }
        public Guid OrderId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; } = null!;
        public int Number { get; set; }
    }
}
