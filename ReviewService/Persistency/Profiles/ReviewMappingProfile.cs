using AutoMapper;
using ReviewService.Domain.Models;
using ReviewService.Presentation.ViewModels;

namespace ReviewService.Persistency.Profiles
{
    public class ReviewMappingProfile:Profile
    {
        public ReviewMappingProfile()
        {
            CreateMap<Review, ReviewVM>().ReverseMap();
        }
    }
}
