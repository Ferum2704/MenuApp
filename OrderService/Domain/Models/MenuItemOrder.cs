using Dapper.Contrib.Extensions;

namespace OrderService.Domain.Models
{
    [Table("[MenuItemOrder]")]
    public class MenuItemOrder
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public Guid MenuItemId { get; set; }
        public Guid OrderId { get; set; }
        public int Number { get; set; }
    }
}
