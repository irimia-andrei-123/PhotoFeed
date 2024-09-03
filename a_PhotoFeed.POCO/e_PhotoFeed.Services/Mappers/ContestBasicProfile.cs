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
    public class ContestBasicProfile: Profile
    {
        public ContestBasicProfile()
        {
            CreateMap<ContestBasic, ContestBasicDTO>()
                .ForMember(dest => dest.IdContestBasic, src => src.MapFrom(x => x.IdContestBasic))
                .ForMember(dest => dest.ContestName, src => src.MapFrom(x => x.ContestName))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.EndDate, src => src.MapFrom(x => x.EndDate))
                .ForMember(dest => dest.IdCreator, src => src.MapFrom(x => x.IdCreator))
                .ForMember(dest => dest.MaximumPictureNumber, src => src.MapFrom(x => x.MaximumPictureNumber))
                .ForMember(dest => dest.StartDate, src => src.MapFrom(x => x.StartDate))
                .ForMember(dest => dest.Closed, src => src.MapFrom(x => x.Closed));

            CreateMap<ContestBasicDTO, ContestBasic>()
                .ForMember(dest => dest.IdContestBasic, src => src.MapFrom(x => x.IdContestBasic))
                .ForMember(dest => dest.ContestName, src => src.MapFrom(x => x.ContestName))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.EndDate, src => src.MapFrom(x => x.EndDate))
                .ForMember(dest => dest.IdCreator, src => src.MapFrom(x => x.IdCreator))
                .ForMember(dest => dest.MaximumPictureNumber, src => src.MapFrom(x => x.MaximumPictureNumber))
                .ForMember(dest => dest.StartDate, src => src.MapFrom(x => x.StartDate))
                .ForMember(dest => dest.Closed, src => src.MapFrom(x => x.Closed))
                .ForMember(dest => dest.User, src => src.Ignore())
                .ForMember(dest => dest.PhotoBasicContests, src => src.Ignore())
                .ForMember(dest => dest.WinnerBasics, src => src.Ignore());

        }
    }
}
