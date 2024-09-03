using System;
using a_PhotoFeed.POCO;
using AutoMapper;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Mappers
{
    public class FeedbackProfile: Profile{
        public FeedbackProfile()
        {
            CreateMap<Feedback, FeedbackDTO>()
                .ForMember(dest => dest.IdFeedback, src => src.MapFrom(x => x.IdFeedback))
                .ForMember(dest => dest.IdCommenter, src => src.MapFrom(x => x.IdCommenter))
                .ForMember(dest => dest.IdPhotoFeedback, src => src.MapFrom(x => x.IdPhotoFeedback))
                .ForMember(dest => dest.GoodParts, src => src.MapFrom(x => x.GoodParts))
                .ForMember(dest => dest.BadParts, src => src.MapFrom(x => x.BadParts))
                .ForMember(dest => dest.Miscellaneous, src => src.MapFrom(x => x.Miscellaneous))
                .ForMember(dest => dest.DatePosted, src => src.MapFrom(x => x.DatePosted))
                .ForMember(dest => dest.Rating, src => src.MapFrom(x => x.Rating));

            CreateMap<FeedbackDTO, Feedback>()
                .ForMember(dest => dest.IdFeedback, src => src.MapFrom(x => x.IdFeedback))
                .ForMember(dest => dest.IdCommenter, src => src.MapFrom(x => x.IdCommenter))
                .ForMember(dest => dest.IdPhotoFeedback, src => src.MapFrom(x => x.IdPhotoFeedback))
                .ForMember(dest => dest.GoodParts, src => src.MapFrom(x => x.GoodParts))
                .ForMember(dest => dest.BadParts, src => src.MapFrom(x => x.BadParts))
                .ForMember(dest => dest.Miscellaneous, src => src.MapFrom(x => x.Miscellaneous))
                .ForMember(dest => dest.DatePosted, src => src.MapFrom(x => x.DatePosted))
                .ForMember(dest => dest.Rating, src => src.MapFrom(x => x.Rating))
                .ForMember(dest => dest.User, src => src.Ignore())
                .ForMember(dest => dest.PhotoFeedbackCategory, src => src.Ignore());
        }
        
    }
}
