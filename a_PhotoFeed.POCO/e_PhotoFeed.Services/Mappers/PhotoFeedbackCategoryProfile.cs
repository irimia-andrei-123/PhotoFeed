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
    public class PhotoFeedbackCategoryProfile: Profile
    {
        public PhotoFeedbackCategoryProfile()
        {
            CreateMap<PhotoFeedbackCategory, PhotoFeedbackCategoryDTO>()
                .ForMember(dest => dest.IdPhotoFeedbackCategory, src => src.MapFrom(x => x.IdPhotoFeedbackCategory))
                .ForMember(dest => dest.IdCategory, src => src.MapFrom(x => x.IdCategory))
                .ForMember(dest => dest.IdPhoto, src => src.MapFrom(x => x.IdPhoto));

            CreateMap<PhotoFeedbackCategoryDTO, PhotoFeedbackCategory>()
                .ForMember(dest => dest.IdPhotoFeedbackCategory, src => src.MapFrom(x => x.IdPhotoFeedbackCategory))
                .ForMember(dest => dest.IdCategory, src => src.MapFrom(x => x.IdCategory))
                .ForMember(dest => dest.IdPhoto, src => src.MapFrom(x => x.IdPhoto))
                .ForMember(dest => dest.Category, src => src.Ignore())
                .ForMember(dest => dest.Feedbacks, src => src.Ignore())
                .ForMember(dest => dest.PhotoFeedback, src => src.Ignore());
        }
    }
}
