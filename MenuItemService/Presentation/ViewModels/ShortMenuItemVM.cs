﻿namespace MenuItemService.Presentation.ViewModels
{
    public class ShortMenuItemVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
