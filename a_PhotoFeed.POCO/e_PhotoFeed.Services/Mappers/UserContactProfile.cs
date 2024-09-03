using a_PhotoFeed.POCO;
using AutoMapper;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Mappers
{
    public class UserContactProfile : Profile
    {
        public UserContactProfile()
        {
            CreateMap<UserContact, UserContactDTO>()
                .ForMember(dest => dest.IdContact, src => src.MapFrom(x => x.IdContact))
                .ForMember(dest => dest.IdContactUser, src => src.MapFrom(x => x.IdContactUser))
                .ForMember(dest => dest.WebsiteName, src => src.MapFrom(x => x.WebsiteName))
                .ForMember(dest => dest.WebsiteUrl, src => src.MapFrom(x => x.WebsiteUrl));

            CreateMap<UserContactDTO, UserContact>()
                .ForMember(dest => dest.IdContact, src => src.MapFrom(x => x.IdContact))
                .ForMember(dest => dest.IdContactUser, src => src.MapFrom(x => x.IdContactUser))
                .ForMember(dest => dest.WebsiteName, src => src.MapFrom(x => x.WebsiteName))
                .ForMember(dest => dest.WebsiteUrl, src => src.MapFrom(x => x.WebsiteUrl))
                .ForMember(dest => dest.User, src => src.Ignore());
        }
    }
}
