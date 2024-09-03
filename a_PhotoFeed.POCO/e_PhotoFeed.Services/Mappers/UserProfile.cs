using a_PhotoFeed.POCO;
using AutoMapper;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Mappers
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.IdUser, src => src.MapFrom(x => x.IdUser))
                .ForMember(dest => dest.UserName, src => src.MapFrom(x => x.UserName))
                .ForMember(dest => dest.Email, src => src.MapFrom(x => x.Email))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.ProfilePicture, src => src.MapFrom(x => x.ProfilePicture))
                .ForMember(dest => dest.Verified, src => src.MapFrom(x => x.Verified))
                .ForMember(dest => dest.Points, src => src.MapFrom(x => x.Points))
                .ForMember(dest => dest.Moderator, src => src.MapFrom(x => x.Moderator))
                .ForMember(dest => dest.Password, src => src.MapFrom(x => x.Password))
                .ForMember(dest => dest.Blocked, src => src.MapFrom(x => x.Blocked));

            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.IdUser, src => src.MapFrom(x => x.IdUser))
                .ForMember(dest => dest.UserName, src => src.MapFrom(x => x.UserName))
                .ForMember(dest => dest.Email, src => src.MapFrom(x => x.Email))
                .ForMember(dest => dest.Password, src => src.Ignore())
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.ProfilePicture, src => src.MapFrom(x => x.ProfilePicture))
                .ForMember(dest => dest.Verified, src => src.MapFrom(x => x.Verified))
                .ForMember(dest => dest.Points, src => src.MapFrom(x => x.Points))
                .ForMember(dest => dest.Moderator, src => src.MapFrom(x => x.Moderator))
                .ForMember(dest => dest.Password, src => src.MapFrom(x => x.Password))
                .ForMember(dest => dest.Blocked, src => src.MapFrom(x => x.Blocked))
                .ForMember(dest => dest.CompanyMembers, src => src.Ignore())
                .ForMember(dest => dest.ContestBasics, src => src.Ignore())
                .ForMember(dest => dest.Feedbacks, src => src.Ignore())
                .ForMember(dest => dest.FollowCompanyUsers, src => src.Ignore())
                .ForMember(dest => dest.FollowUserCategories, src => src.Ignore())
                .ForMember(dest => dest.FollowUserCompanies, src => src.Ignore())
                .ForMember(dest => dest.FollowUserUsers, src => src.Ignore())
                .ForMember(dest => dest.FollowUserUsers1, src => src.Ignore())
                .ForMember(dest => dest.JudgeInvitations, src => src.Ignore())
                .ForMember(dest => dest.Juries, src => src.Ignore())
                .ForMember(dest => dest.ModeratorStat, src => src.Ignore())
                .ForMember(dest => dest.PhotoBasicContests, src => src.Ignore())
                .ForMember(dest => dest.PhotoFeedbacks, src => src.Ignore())
                .ForMember(dest => dest.PhotoProContests, src => src.Ignore())
                .ForMember(dest => dest.PhotoUsers, src => src.Ignore())
                .ForMember(dest => dest.VerificationStat, src => src.Ignore())
                .ForMember(dest => dest.UserContacts, src => src.Ignore())
                .ForMember(dest => dest.UserSpecializations, src => src.Ignore())
                .ForMember(dest => dest.WinnerBasics, src => src.Ignore())
                .ForMember(dest => dest.WinnerProes, src => src.Ignore());
        }
    }
}
