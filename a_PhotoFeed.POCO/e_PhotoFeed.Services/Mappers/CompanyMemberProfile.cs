using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using a_PhotoFeed.POCO;
using AutoMapper;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Mappers
{
    public class CompanyMemberProfile : Profile
    {
        public CompanyMemberProfile()
        {
            CreateMap<CompanyMember, CompanyMemberDTO>()
                .ForMember(dest => dest.IdCompanyMember, src => src.MapFrom(x => x.IdCompanyMember))
                .ForMember(dest => dest.IdUser, src => src.MapFrom(x => x.IdUser))
                .ForMember(dest => dest.IdCompany, src => src.MapFrom(x => x.IdCompany));

            CreateMap<CompanyMemberDTO, CompanyMember>()
                .ForMember(dest => dest.IdCompanyMember, src => src.MapFrom(x => x.IdCompanyMember))
                .ForMember(dest => dest.IdUser, src => src.MapFrom(x => x.IdUser))
                .ForMember(dest => dest.IdCompany, src => src.MapFrom(x => x.IdCompany))
                .ForMember(dest => dest.Company, src => src.Ignore())
                .ForMember(dest => dest.User, src => src.Ignore());        }
    }
}
