using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using a_PhotoFeed.POCO;

namespace c_PhotoFeed.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Category> Categories { get; }
        IRepository<Company> Companies { get; }
        IRepository<CompanyContact> CompanyContacts { get; }
        IRepository<CompanyMember> CompanyMembers { get; }
        IRepository<ContestBasic> ContestBasics { get; }
        IRepository<ContestPro> ContestProes { get; }
        IRepository<CopyrightStat> CopyrightStats { get; }
        IRepository<Feedback> Feedbacks { get; }
        IRepository<FollowCompanyCategory> FollowCompanyCategories { get; }
        IRepository<FollowCompanyCompany> FollowCompanyCompanies { get; }
        IRepository<FollowCompanyUser> FollowCompanyUsers { get; }
        IRepository<FollowUserCategory> FollowUserCategories { get; }
        IRepository<FollowUserCompany> FollowUserCompanies { get; }
        IRepository<FollowUserUser> FollowUserUsers { get; }
        IRepository<InvitationAcceptStat> InvitationAcceptStats { get; }
        IRepository<JudgeInvitation> JudgeInvitations { get; }
        IRepository<Jury> Juries { get; }
        IRepository<ModeratorStat> ModeratorStats { get; }
        IRepository<PhotoBasicContest> PhotoBasicContests { get; }
        IRepository<PhotoFeedback> PhotoFeedbacks { get; }
        IRepository<PhotoFeedbackCategory> PhotoFeedbackCategories { get; }
        IRepository<PhotoProContest> PhotoProContests { get; }
        IRepository<PhotoTag> PhotoTags { get; }
        IRepository<PhotoUser> PhotoUsers { get; }
        IRepository<PhotoUserCategory> PhotoUserCategories { get; }
        IRepository<PositionStat> PositionStats { get; }
        IRepository<PrizeProContest> PrizeProContests { get; }
        IRepository<Specialization> Specializations { get; }
        IRepository<Tag> Tags { get; }
        IRepository<User> Users { get; }
        IRepository<UserContact> UserContacts { get; }
        IRepository<UserSpecialization> UserSpecializations { get; }
        IRepository<VerificationStat> VerificationStats { get; }
        IRepository<WinnerBasic> WinnerBasics { get; }
        IRepository<WinnerPro> WinnerProes { get; }

        void Commit();
    }
}
