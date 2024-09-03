using System.Collections.Generic;
using a_PhotoFeed.POCO;
using d_PhotoFeed.DTO;
using AutoMapper;

namespace e_PhotoFeed.Services.Mappers
{
    public class CompanyProfile: Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDTO>()
                .ForMember(dest => dest.IdCompany, src => src.MapFrom(x => x.IdCompany))
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(x => x.CompanyName))
                .ForMember(dest => dest.Email, src => src.MapFrom(x => x.Email))
                .ForMember(dest => dest.Password, src => src.MapFrom(x => x.Password))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.ProfilePicture, src => src.MapFrom(x => x.ProfilePicture))
                .ForMember(dest => dest.Allowed, src => src.MapFrom(x => x.Allowed));

            CreateMap<CompanyDTO, Company>()
                .ForMember(dest => dest.IdCompany, src => src.MapFrom(x => x.IdCompany))
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(x => x.CompanyName))
                .ForMember(dest => dest.Email, src => src.MapFrom(x => x.Email))
                .ForMember(dest => dest.Password, src => src.MapFrom(x => x.Password))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.ProfilePicture, src => src.MapFrom(x => x.ProfilePicture))
                .ForMember(dest => dest.Allowed, src => src.MapFrom(x => x.Allowed))
                .ForMember(dest => dest.CompanyContacts, src => src.Ignore())
                .ForMember(dest => dest.CompanyMembers, src => src.Ignore())
                .ForMember(dest => dest.ContestProes, src => src.Ignore())
                .ForMember(dest => dest.FollowCompanyUsers, src => src.Ignore())
                .ForMember(dest => dest.FollowCompanyCategories, src => src.Ignore())
                .ForMember(dest => dest.FollowCompanyCompanies, src => src.Ignore())
                .ForMember(dest => dest.FollowCompanyCompanies1, src => src.Ignore())
                .ForMember(dest => dest.FollowUserCompanies, src => src.Ignore())
                .ForMember(dest => dest.JudgeInvitations, src => src.Ignore());
        }
    }
}
