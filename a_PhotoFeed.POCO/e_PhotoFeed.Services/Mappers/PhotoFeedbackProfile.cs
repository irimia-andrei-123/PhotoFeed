using a_PhotoFeed.POCO;
using AutoMapper;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Mappers
{
    public class PhotoFeedbackProfile: Profile
    {
        public PhotoFeedbackProfile()
        {
            CreateMap<PhotoFeedback, PhotoFeedbackDTO>()
                .ForMember(dest => dest.IdPhotoFeedback, src => src.MapFrom(x => x.IdPhotoFeedback))
                .ForMember(dest => dest.IdUser, src => src.MapFrom(x => x.IdUser))
                .ForMember(dest => dest.Copyrighted, src => src.MapFrom(x => x.Copyrighted))
                .ForMember(dest => dest.Photo, src => src.MapFrom(x => x.Photo))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.DatePosted, src => src.MapFrom(x => x.DatePosted));

            CreateMap<PhotoFeedbackDTO, PhotoFeedback>()
                .ForMember(dest => dest.IdPhotoFeedback, src => src.MapFrom(x => x.IdPhotoFeedback))
                .ForMember(dest => dest.IdUser, src => src.MapFrom(x => x.IdUser))
                .ForMember(dest => dest.Copyrighted, src => src.MapFrom(x => x.Copyrighted))
                .ForMember(dest => dest.Photo, src => src.MapFrom(x => x.Photo))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.DatePosted, src => src.MapFrom(x => x.DatePosted))
                .ForMember(dest => dest.DatePosted, src => src.MapFrom(x => x.DatePosted))
                .ForMember(dest => dest.DatePosted, src => src.MapFrom(x => x.DatePosted))
                .ForMember(dest => dest.CopyrightStat, src => src.Ignore())
                .ForMember(dest => dest.PhotoFeedbackCategories, src => src.Ignore())
                .ForMember(dest => dest.User, src => src.Ignore());
        }
    }
}
