using AutoMapper;
using ReviewService.Domain.Models;
using ReviewService.Presentation.ViewModels;

namespace ReviewService.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Review, ReviewVM>().ReverseMap();
        }
    }
}
