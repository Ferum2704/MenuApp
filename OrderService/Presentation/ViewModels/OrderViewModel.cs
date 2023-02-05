using OrderService.Domain.Models;

namespace OrderService.Presentation.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public Guid VisitorId { get; set; }
        public IEnumerable<MenuItemOrderViewModel> OrderedMenuItems { get; set; } = new List<MenuItemOrderViewModel>();
    }
}
