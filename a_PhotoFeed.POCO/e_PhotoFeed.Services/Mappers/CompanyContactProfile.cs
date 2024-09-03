using a_PhotoFeed.POCO;
using AutoMapper;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Mappers
{
    public class CompanyContactProfile: Profile
    {
        public CompanyContactProfile()
        {
            CreateMap<CompanyContact, CompanyContactDTO>()
                .ForMember(dest => dest.IdContact, src => src.MapFrom(x => x.IdContact))
                .ForMember(dest => dest.IdContactCompany, src => src.MapFrom(x => x.IdContactCompany))
                .ForMember(dest => dest.WebsiteName, src => src.MapFrom(x => x.WebsiteName))
                .ForMember(dest => dest.WebsiteUrl, src => src.MapFrom(x => x.WebsiteUrl));

            CreateMap<CompanyContactDTO, CompanyContact>()
                .ForMember(dest => dest.IdContact, src => src.MapFrom(x => x.IdContact))
                .ForMember(dest => dest.IdContactCompany, src => src.MapFrom(x => x.IdContactCompany))
                .ForMember(dest => dest.WebsiteName, src => src.MapFrom(x => x.WebsiteName))
                .ForMember(dest => dest.WebsiteUrl, src => src.MapFrom(x => x.WebsiteUrl))
                .ForMember(dest => dest.Company, src => src.Ignore());
        }
    }
}
