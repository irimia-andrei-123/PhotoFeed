using System;
using a_PhotoFeed.POCO;
using b_PhotoFeed.DataAccess;
using c_PhotoFeed.Repository.Interfaces;

namespace c_PhotoFeed.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        readonly IPhotoFeedContext _photoFeedContext;

        public UnitOfWork(PhotoFeedContext photoFeedContext)
        {
            _photoFeedContext = photoFeedContext;
            _photoFeedContext.Context.Configuration.LazyLoadingEnabled = false;
        }

        public IRepository<Category> Categories => new Repository<Category>(_photoFeedContext);

        public IRepository<Company> Companies => new Repository<Company>(_photoFeedContext);

        public IRepository<CompanyContact> CompanyContacts => new Repository<CompanyContact>(_photoFeedContext);

        public IRepository<CompanyMember> CompanyMembers => new Repository<CompanyMember>(_photoFeedContext);

        public IRepository<ContestBasic> ContestBasics => new Repository<ContestBasic>(_photoFeedContext);

        public IRepository<ContestPro> ContestProes => new Repository<ContestPro>(_photoFeedContext);

        public IRepository<CopyrightStat> CopyrightStats => new Repository<CopyrightStat>(_photoFeedContext);

        public IRepository<Feedback> Feedbacks => new Repository<Feedback>(_photoFeedContext);

        public IRepository<FollowCompanyCategory> FollowCompanyCategories => new Repository<FollowCompanyCategory>(_photoFeedContext);

        public IRepository<FollowCompanyCompany> FollowCompanyCompanies => new Repository<FollowCompanyCompany>(_photoFeedContext);

        public IRepository<FollowCompanyUser> FollowCompanyUsers => new Repository<FollowCompanyUser>(_photoFeedContext);

        public IRepository<FollowUserCategory> FollowUserCategories => new Repository<FollowUserCategory>(_photoFeedContext);

        public IRepository<FollowUserCompany> FollowUserCompanies => new Repository<FollowUserCompany>(_photoFeedContext);

        public IRepository<FollowUserUser> FollowUserUsers => new Repository<FollowUserUser>(_photoFeedContext);

        public IRepository<InvitationAcceptStat> InvitationAcceptStats => new Repository<InvitationAcceptStat>(_photoFeedContext);

        public IRepository<JudgeInvitation> JudgeInvitations => new Repository<JudgeInvitation>(_photoFeedContext);

        public IRepository<Jury> Juries => new Repository<Jury>(_photoFeedContext);

        public IRepository<ModeratorStat> ModeratorStats => new Repository<ModeratorStat>(_photoFeedContext);

        public IRepository<PhotoBasicContest> PhotoBasicContests => new Repository<PhotoBasicContest>(_photoFeedContext);

        public IRepository<PhotoFeedback> PhotoFeedbacks => new Repository<PhotoFeedback>(_photoFeedContext);

        public IRepository<PhotoFeedbackCategory> PhotoFeedbackCategories => new Repository<PhotoFeedbackCategory>(_photoFeedContext);

        public IRepository<PhotoProContest> PhotoProContests => new Repository<PhotoProContest>(_photoFeedContext);

        public IRepository<PhotoTag> PhotoTags => new Repository<PhotoTag>(_photoFeedContext);

        public IRepository<PhotoUser> PhotoUsers => new Repository<PhotoUser>(_photoFeedContext);

        public IRepository<PhotoUserCategory> PhotoUserCategories => new Repository<PhotoUserCategory>(_photoFeedContext);

        public IRepository<PositionStat> PositionStats => new Repository<PositionStat>(_photoFeedContext);

        public IRepository<PrizeProContest> PrizeProContests => new Repository<PrizeProContest>(_photoFeedContext);

        public IRepository<Specialization> Specializations => new Repository<Specialization>(_photoFeedContext);

        public IRepository<Tag> Tags => new Repository<Tag>(_photoFeedContext);

        public IRepository<User> Users => new Repository<User>(_photoFeedContext);

        public IRepository<UserContact> UserContacts => new Repository<UserContact>(_photoFeedContext);

        public IRepository<UserSpecialization> UserSpecializations => new Repository<UserSpecialization>(_photoFeedContext);

        public IRepository<VerificationStat> VerificationStats => new Repository<VerificationStat>(_photoFeedContext);

        public IRepository<WinnerBasic> WinnerBasics => new Repository<WinnerBasic>(_photoFeedContext);

        public IRepository<WinnerPro> WinnerProes => new Repository<WinnerPro>(_photoFeedContext);

        public void Commit()
        {
            _photoFeedContext.Context.SaveChanges();
        }

        public void Dispose()
        {
            _photoFeedContext.Context.Dispose();
        }
    }
}
