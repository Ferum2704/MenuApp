using Dapper.Contrib.Extensions;

namespace OrderService.Domain.Models
{
    [Table("[Order]")]
    public class Order
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string Status { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public Guid VisitorId { get; set; }
        [Write(false)]
        public IEnumerable<MenuItemOrder> OrderedMenuItems { get; set; } = new List<MenuItemOrder>();
    }
}
