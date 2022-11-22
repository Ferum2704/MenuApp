namespace ReviewService.Domain.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string? Description { get; set; }
        public Guid MenuItemId { get; set; }
        public DateTime PostDate { get; set; }
    }
}
