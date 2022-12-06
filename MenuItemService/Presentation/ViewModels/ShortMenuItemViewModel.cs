﻿namespace MenuItemService.Presentation.ViewModels
{
    public class ShortMenuItemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhotoUrl { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
