namespace ReviewService.Presentation.ViewModels
{
    public class ReviewVM
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string? Description { get; set; }
        public Guid MenuItemId { get; set; }
        public DateTime PostDate { get; set; }
    }
}
