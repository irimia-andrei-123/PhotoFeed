using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using a_PhotoFeed.POCO;
using AutoMapper;
using c_PhotoFeed.Repository.Interfaces;
using d_PhotoFeed.DTO;
using e_PhotoFeed.Services.Interfaces;

namespace e_PhotoFeed.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _uow;

        public CompanyService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void AllowCompany(int companyId)
        {
            var company = _uow.Companies.Where(x => x.IdCompany == companyId).SingleOrDefault();
            company.Allowed = 1;
            _uow.Companies.Save();
        }

        public CompanyProfileData GetCompanyProfile(int companyId)
        {
            var companyProfileData = new CompanyProfileData();
            var company = _uow.Companies.Find(x => x.IdCompany == companyId).FirstOrDefault();
            companyProfileData.IdCompany = company.IdCompany;
            companyProfileData.CompanyName = company.CompanyName;
            companyProfileData.Email = company.Email;
            companyProfileData.Description = company.Description;
            companyProfileData.ProfilePicture = company.ProfilePicture;
            companyProfileData.Contact = Mapper.Map<List<CompanyContact>, List<CompanyContactDTO>>(_uow.CompanyContacts.Where(x => x.IdContactCompany == companyId).ToList());
            return companyProfileData;
        }

        public void DenyCompany(int companyId)
        {
            var company = _uow.Companies.Where(x => x.IdCompany == companyId).SingleOrDefault();
            company.Allowed = -1;
            _uow.Companies.Save();
        }

        public List<CompanyDTO> GetPendingCompanies()
        {
            var companies = _uow.Companies.GetAll().Where(x => x.Allowed == 0).ToList();
            return Mapper.Map<List<Company>, List<CompanyDTO>>(companies);
        }

        public List<UserProfileData> GetCompanyMembers(int companyId)
        {
            var users = _uow.CompanyMembers.Where(x => x.IdCompany == companyId).Select(x => x.IdUser);

            var usersProfileData = new List<UserProfileData>();
            foreach (var userId in users)
            {
                var user = _uow.Users.Find(x => x.IdUser == userId).FirstOrDefault();
                var userProfileData = new UserProfileData();
                userProfileData.IdUser = user.IdUser;
                userProfileData.UserName = user.UserName;
                userProfileData.Email = user.Email;
                userProfileData.Description = user.Description;
                userProfileData.ProfilePicture = user.ProfilePicture;
                userProfileData.Points = user.Points;
                userProfileData.Blocked = user.Blocked;
                userProfileData.Contact = Mapper.Map<List<UserContact>, List<UserContactDTO>>(_uow.UserContacts.Where(x => x.IdContactUser == userId).ToList());
                usersProfileData.Add(userProfileData);
            }
            
            return usersProfileData;
        }
    }
}
