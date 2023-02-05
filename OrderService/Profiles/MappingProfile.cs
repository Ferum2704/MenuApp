using AutoMapper;
using OrderService.Domain.Models;
using OrderService.Presentation.ViewModels;

namespace OrderService.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderViewModel, Order>().ReverseMap();
            CreateMap<MenuItemOrder, MenuItemOrderViewModel>().ReverseMap();
        }
    }
}
