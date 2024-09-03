using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using c_PhotoFeed.Repository.Implementations;
using c_PhotoFeed.Repository.Interfaces;
using e_PhotoFeed.Services.Implementations;
using e_PhotoFeed.Services.Interfaces;
using e_PhotoFeed.Services.Mappers;
using Unity;

namespace e_PhotoFeed.Services
{
    public class ServicesBootstrap
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<CategoryProfile>();
                cfg.AddProfile<PhotoFeedbackProfile>();
                cfg.AddProfile<PhotoFeedbackCategoryProfile>();
                cfg.AddProfile<PhotoUserProfile>();
                cfg.AddProfile<PhotoUserCategoryProfile>();
                cfg.AddProfile<PhotoTagProfile>();
                cfg.AddProfile<TagProfile>();
                cfg.AddProfile<ContestBasicProfile>();
                cfg.AddProfile<PhotoBasicContestProfile>();
                cfg.AddProfile<ContestProProfile>();
                cfg.AddProfile<PhotoProContestProfile>();
                cfg.AddProfile<UserContactProfile>();
                cfg.AddProfile<CompanyMemberProfile>();
                cfg.AddProfile<FeedbackProfile>();
                cfg.AddProfile<CompanyContactProfile>();
            });

            Mapper.AssertConfigurationIsValid();
        }

        public static UnityContainer ConfigureUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IFeedbackService, FeedbackService>();
            container.RegisterType<ISearchpageService, SearchpageService>();
            container.RegisterType<IContestBasicService, ContestBasicService>();
            container.RegisterType<IImageService, ImageService>();
            container.RegisterType<ICompanyService, CompanyService>();
            container.RegisterType<IContestProService, ContestProService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            return container;
        }
    }
}
