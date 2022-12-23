using AutoMapper;
using MenuItemService.Domain.Models;
using MenuItemService.Presentation.ViewModels;

namespace MenuItemService.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MenuItem, ShortMenuItemViewModel>().ReverseMap();
        }
    }
}
