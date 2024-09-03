using a_PhotoFeed.POCO;
using AutoMapper;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Mappers
{
    public class PhotoUserProfile: Profile
    {
        public PhotoUserProfile()
        {
            CreateMap<PhotoUser, PhotoUserDTO>()
                .ForMember(dest => dest.IdPhotoUser, src => src.MapFrom(x => x.IdPhotoUser))
                .ForMember(dest => dest.IdUser, src => src.MapFrom(x => x.IdUser))
                .ForMember(dest => dest.Copyrighted, src => src.MapFrom(x => x.Copyrighted))
                .ForMember(dest => dest.Photo, src => src.MapFrom(x => x.Photo))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.DatePosted, src => src.MapFrom(x => x.DatePosted))
                .ForMember(dest => dest.Rating, src => src.MapFrom(x => x.Rating));

            CreateMap<PhotoUserDTO, PhotoUser>()
                .ForMember(dest => dest.IdPhotoUser, src => src.MapFrom(x => x.IdPhotoUser))
                .ForMember(dest => dest.IdUser, src => src.MapFrom(x => x.IdUser))
                .ForMember(dest => dest.Copyrighted, src => src.MapFrom(x => x.Copyrighted))
                .ForMember(dest => dest.Photo, src => src.MapFrom(x => x.Photo))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.DatePosted, src => src.MapFrom(x => x.DatePosted))
                .ForMember(dest => dest.Rating, src => src.MapFrom(x => x.Rating))
                .ForMember(dest => dest.CopyrightStat, src => src.Ignore())
                .ForMember(dest => dest.PhotoTags, src => src.Ignore())
                .ForMember(dest => dest.PhotoUserCategories, src => src.Ignore())
                .ForMember(dest => dest.User, src => src.Ignore());
        }
    }
}
