namespace OrderService.Presentation.ViewModels
{
    public class MenuItemOrderViewModel
    {
        public Guid Id { get; set; }
        public Guid MenuItemId { get; set; }
        public Guid OrderId { get; set; }
        public int Number { get; set; }
    }
}
