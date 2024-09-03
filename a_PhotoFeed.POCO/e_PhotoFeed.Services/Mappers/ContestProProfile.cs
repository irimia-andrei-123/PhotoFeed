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
    public class ContestProProfile : Profile
    {
        public ContestProProfile()
        {
            CreateMap<ContestPro, ContestProDTO>()
                .ForMember(dest => dest.IdContestPro, src => src.MapFrom(x => x.IdContestPro))
                .ForMember(dest => dest.ContestName, src => src.MapFrom(x => x.ContestName))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.EndDate, src => src.MapFrom(x => x.EndDate))
                .ForMember(dest => dest.IdCreator, src => src.MapFrom(x => x.IdCreator))
                .ForMember(dest => dest.MaximumPictureNumber, src => src.MapFrom(x => x.MaximumPictureNumber))
                .ForMember(dest => dest.StartDate, src => src.MapFrom(x => x.StartDate))
                .ForMember(dest => dest.Closed, src => src.MapFrom(x => x.Closed));

            CreateMap<ContestProDTO, ContestPro>()
                .ForMember(dest => dest.IdContestPro, src => src.MapFrom(x => x.IdContestPro))
                .ForMember(dest => dest.ContestName, src => src.MapFrom(x => x.ContestName))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.EndDate, src => src.MapFrom(x => x.EndDate))
                .ForMember(dest => dest.IdCreator, src => src.MapFrom(x => x.IdCreator))
                .ForMember(dest => dest.MaximumPictureNumber, src => src.MapFrom(x => x.MaximumPictureNumber))
                .ForMember(dest => dest.StartDate, src => src.MapFrom(x => x.StartDate))
                .ForMember(dest => dest.Closed, src => src.MapFrom(x => x.Closed))
                .ForMember(dest => dest.JudgeInvitations, src => src.Ignore())
                .ForMember(dest => dest.Juries, src => src.Ignore())
                .ForMember(dest => dest.PhotoProContests, src => src.Ignore())
                .ForMember(dest => dest.PrizeProContests, src => src.Ignore())
                .ForMember(dest => dest.WinnerProes, src => src.Ignore())
                .ForMember(dest => dest.Company, src => src.Ignore());
        }
    }
}
