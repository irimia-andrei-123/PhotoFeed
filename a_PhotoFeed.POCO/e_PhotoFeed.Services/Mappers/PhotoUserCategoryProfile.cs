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
    public class PhotoUserCategoryProfile : Profile
    {
        public PhotoUserCategoryProfile()
        {
            CreateMap<PhotoUserCategory, PhotoUserCategoryDTO>()
                .ForMember(dest => dest.IdPhotoUserCategory, src => src.MapFrom(x => x.IdPhotoUserCategory))
                .ForMember(dest => dest.IdCategory, src => src.MapFrom(x => x.IdCategory))
                .ForMember(dest => dest.IdPhoto, src => src.MapFrom(x => x.IdPhoto));

            CreateMap<PhotoUserCategoryDTO, PhotoUserCategory>()
                .ForMember(dest => dest.IdPhotoUserCategory, src => src.MapFrom(x => x.IdPhotoUserCategory))
                .ForMember(dest => dest.IdCategory, src => src.MapFrom(x => x.IdCategory))
                .ForMember(dest => dest.IdPhoto, src => src.MapFrom(x => x.IdPhoto))
                .ForMember(dest => dest.Category, src => src.Ignore())
                .ForMember(dest => dest.PhotoUser, src => src.Ignore());
        }
    }
}
