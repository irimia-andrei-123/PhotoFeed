namespace a_PhotoFeed.POCO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using b_PhotoFeed.DataAccess;
    using a_PhotoFeed.POCO;

    public partial class PhotoFeedContext : DbContext, IPhotoFeedContext
    {
        public PhotoFeedContext()
            : base("name=PhotoFeedContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyContact> CompanyContacts { get; set; }
        public virtual DbSet<CompanyMember> CompanyMembers { get; set; }
        public virtual DbSet<ContestBasic> ContestBasics { get; set; }
        public virtual DbSet<ContestPro> ContestProes { get; set; }
        public virtual DbSet<CopyrightStat> CopyrightStats { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<FollowCompanyCategory> FollowCompanyCategories { get; set; }
        public virtual DbSet<FollowCompanyCompany> FollowCompanyCompanies { get; set; }
        public virtual DbSet<FollowCompanyUser> FollowCompanyUsers { get; set; }
        public virtual DbSet<FollowUserCategory> FollowUserCategories { get; set; }
        public virtual DbSet<FollowUserCompany> FollowUserCompanies { get; set; }
        public virtual DbSet<FollowUserUser> FollowUserUsers { get; set; }
        public virtual DbSet<InvitationAcceptStat> InvitationAcceptStats { get; set; }
        public virtual DbSet<JudgeInvitation> JudgeInvitations { get; set; }
        public virtual DbSet<Jury> Juries { get; set; }
        public virtual DbSet<ModeratorStat> ModeratorStats { get; set; }
        public virtual DbSet<PhotoBasicContest> PhotoBasicContests { get; set; }
        public virtual DbSet<PhotoFeedback> PhotoFeedbacks { get; set; }
        public virtual DbSet<PhotoFeedbackCategory> PhotoFeedbackCategories { get; set; }
        public virtual DbSet<PhotoProContest> PhotoProContests { get; set; }
        public virtual DbSet<PhotoTag> PhotoTags { get; set; }
        public virtual DbSet<PhotoUser> PhotoUsers { get; set; }
        public virtual DbSet<PhotoUserCategory> PhotoUserCategories { get; set; }
        public virtual DbSet<PositionStat> PositionStats { get; set; }
        public virtual DbSet<PrizeProContest> PrizeProContests { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserContact> UserContacts { get; set; }
        public virtual DbSet<UserSpecialization> UserSpecializations { get; set; }
        public virtual DbSet<VerificationStat> VerificationStats { get; set; }
        public virtual DbSet<WinnerBasic> WinnerBasics { get; set; }
        public virtual DbSet<WinnerPro> WinnerProes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.FollowCompanyCategories)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.IdCategoryFollowed)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.FollowUserCategories)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.IdCategoryFollowed)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.PhotoFeedbackCategories)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.PhotoUserCategories)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.CompanyContacts)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.IdContactCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.CompanyMembers)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.ContestProes)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.IdCreator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.FollowCompanyUsers)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.FollowCompanyCategories)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.FollowCompanyCompanies)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.IdCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.FollowCompanyCompanies1)
                .WithRequired(e => e.Company1)
                .HasForeignKey(e => e.IdCompanyFollowed)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.FollowUserCompanies)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.IdCompanyFollowed)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.JudgeInvitations)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContestBasic>()
                .HasMany(e => e.PhotoBasicContests)
                .WithRequired(e => e.ContestBasic)
                .HasForeignKey(e => e.IdBasicContest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContestBasic>()
                .HasMany(e => e.WinnerBasics)
                .WithRequired(e => e.ContestBasic)
                .HasForeignKey(e => e.IdBasicContest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContestPro>()
                .HasMany(e => e.JudgeInvitations)
                .WithRequired(e => e.ContestPro)
                .HasForeignKey(e => e.IdContest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContestPro>()
                .HasMany(e => e.Juries)
                .WithRequired(e => e.ContestPro)
                .HasForeignKey(e => e.IdProContest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContestPro>()
                .HasMany(e => e.PhotoProContests)
                .WithRequired(e => e.ContestPro)
                .HasForeignKey(e => e.IdProContest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContestPro>()
                .HasMany(e => e.PrizeProContests)
                .WithRequired(e => e.ContestPro)
                .HasForeignKey(e => e.IdProContest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContestPro>()
                .HasMany(e => e.WinnerProes)
                .WithRequired(e => e.ContestPro)
                .HasForeignKey(e => e.IdProContest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CopyrightStat>()
                .HasMany(e => e.PhotoBasicContests)
                .WithRequired(e => e.CopyrightStat)
                .HasForeignKey(e => e.Copyrighted)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CopyrightStat>()
                .HasMany(e => e.PhotoFeedbacks)
                .WithRequired(e => e.CopyrightStat)
                .HasForeignKey(e => e.Copyrighted)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CopyrightStat>()
                .HasMany(e => e.PhotoProContests)
                .WithRequired(e => e.CopyrightStat)
                .HasForeignKey(e => e.Copyrighted)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CopyrightStat>()
                .HasMany(e => e.PhotoUsers)
                .WithRequired(e => e.CopyrightStat)
                .HasForeignKey(e => e.Copyrighted)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InvitationAcceptStat>()
                .HasMany(e => e.JudgeInvitations)
                .WithRequired(e => e.InvitationAcceptStat)
                .HasForeignKey(e => e.Accepted)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ModeratorStat>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.ModeratorStat)
                .HasForeignKey(e => e.Moderator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhotoFeedback>()
                .HasMany(e => e.PhotoFeedbackCategories)
                .WithRequired(e => e.PhotoFeedback)
                .HasForeignKey(e => e.IdPhoto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhotoFeedbackCategory>()
                .HasMany(e => e.Feedbacks)
                .WithRequired(e => e.PhotoFeedbackCategory)
                .HasForeignKey(e => e.IdPhotoFeedback)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhotoUser>()
                .HasMany(e => e.PhotoTags)
                .WithRequired(e => e.PhotoUser)
                .HasForeignKey(e => e.IdPhoto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhotoUser>()
                .HasMany(e => e.PhotoUserCategories)
                .WithRequired(e => e.PhotoUser)
                .HasForeignKey(e => e.IdPhoto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PositionStat>()
                .HasMany(e => e.WinnerBasics)
                .WithRequired(e => e.PositionStat)
                .HasForeignKey(e => e.PositionPlaced)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PositionStat>()
                .HasMany(e => e.WinnerProes)
                .WithRequired(e => e.PositionStat)
                .HasForeignKey(e => e.PositionPlaced)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specialization>()
                .HasMany(e => e.UserSpecializations)
                .WithRequired(e => e.Specialization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.PhotoTags)
                .WithRequired(e => e.Tag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CompanyMembers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ContestBasics)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdCreator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Feedbacks)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdCommenter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FollowCompanyUsers)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUserFollowed)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FollowUserCategories)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FollowUserCompanies)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FollowUserUsers)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FollowUserUsers1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.IdUserFollowed)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.JudgeInvitations)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUserInvited)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Juries)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdJuryUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PhotoBasicContests)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PhotoFeedbacks)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PhotoProContests)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PhotoUsers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserContacts)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdContactUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserSpecializations)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUserSpec)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.WinnerBasics)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdWinnerUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.WinnerProes)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdWinnerUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VerificationStat>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.VerificationStat)
                .HasForeignKey(e => e.Verified)
                .WillCascadeOnDelete(false);
        }

        public DbContext Context
        {
            get { return this; }
        }

        public IDbSet<T> Set<T>() where T : class
        {
            return Context.Set<T>();
        }
    }
}
