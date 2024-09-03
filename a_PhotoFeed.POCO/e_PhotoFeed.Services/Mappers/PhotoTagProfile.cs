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
    public class PhotoTagProfile: Profile
    {
        public PhotoTagProfile()
        {
            CreateMap<PhotoTag, PhotoTagDTO>()
                .ForMember(dest => dest.IdPhotoTag, src => src.MapFrom(x => x.IdPhotoTag))
                .ForMember(dest => dest.IdTag, src => src.MapFrom(x => x.IdTag))
                .ForMember(dest => dest.IdPhoto, src => src.MapFrom(x => x.IdPhoto));

            CreateMap<PhotoTagDTO, PhotoTag>()
                .ForMember(dest => dest.IdPhotoTag, src => src.MapFrom(x => x.IdPhotoTag))
                .ForMember(dest => dest.IdTag, src => src.MapFrom(x => x.IdTag))
                .ForMember(dest => dest.IdPhoto, src => src.MapFrom(x => x.IdPhoto))
                .ForMember(dest => dest.PhotoUser, src => src.Ignore())
                .ForMember(dest => dest.Tag, src => src.Ignore());
        }

    }
}
