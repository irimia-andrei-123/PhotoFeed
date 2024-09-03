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
    public class PhotoProContestProfile : Profile
    {
        public PhotoProContestProfile()
        {
            CreateMap<PhotoProContest, PhotoProContestDTO>()
                .ForMember(dest => dest.IdUser, src => src.MapFrom(x => x.IdUser))
                .ForMember(dest => dest.Copyrighted, src => src.MapFrom(x => x.Copyrighted))
                .ForMember(dest => dest.DatePosted, src => src.MapFrom(x => x.DatePosted))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.IdProContest, src => src.MapFrom(x => x.IdProContest))
                .ForMember(dest => dest.IdPhotoProContest, src => src.MapFrom(x => x.IdPhotoProContest))
                .ForMember(dest => dest.Photo, src => src.MapFrom(x => x.Photo))
                .ForMember(dest => dest.Rating, src => src.MapFrom(x => x.Rating));

            CreateMap<PhotoProContestDTO, PhotoProContest>()
                .ForMember(dest => dest.IdUser, src => src.MapFrom(x => x.IdUser))
                .ForMember(dest => dest.Copyrighted, src => src.MapFrom(x => x.Copyrighted))
                .ForMember(dest => dest.DatePosted, src => src.MapFrom(x => x.DatePosted))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.IdProContest, src => src.MapFrom(x => x.IdProContest))
                .ForMember(dest => dest.IdPhotoProContest, src => src.MapFrom(x => x.IdPhotoProContest))
                .ForMember(dest => dest.Photo, src => src.MapFrom(x => x.Photo))
                .ForMember(dest => dest.Rating, src => src.MapFrom(x => x.Rating))
                .ForMember(dest => dest.ContestPro, src => src.Ignore())
                .ForMember(dest => dest.User, src => src.Ignore())
                .ForMember(dest => dest.CopyrightStat, src => src.Ignore());

        }
    }
}