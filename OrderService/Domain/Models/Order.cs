namespace OrderService.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public Guid VisitorId { get; set; }
    }
}
