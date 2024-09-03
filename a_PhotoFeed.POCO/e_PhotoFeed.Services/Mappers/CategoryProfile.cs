using a_PhotoFeed.POCO;
using AutoMapper;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Mappers
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.IdCategory, src => src.MapFrom(x => x.IdCategory))
                .ForMember(dest => dest.CategoryName, src => src.MapFrom(x => x.CategoryName))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description));

            CreateMap<CategoryDTO, Category>()
                .ForMember(dest => dest.IdCategory, src => src.MapFrom(x => x.IdCategory))
                .ForMember(dest => dest.CategoryName, src => src.MapFrom(x => x.CategoryName))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.FollowCompanyCategories, src => src.Ignore())
                .ForMember(dest => dest.FollowUserCategories, src => src.Ignore())
                .ForMember(dest => dest.PhotoFeedbackCategories, src => src.Ignore())
                .ForMember(dest => dest.PhotoUserCategories, src => src.Ignore());
        }
    }
}
