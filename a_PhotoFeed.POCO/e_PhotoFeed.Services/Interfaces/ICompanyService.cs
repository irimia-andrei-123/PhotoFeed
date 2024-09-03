using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Interfaces
{
    public interface ICompanyService
    {
        List<CompanyDTO> GetPendingCompanies();
        void DenyCompany(int companyId);
        void AllowCompany(int companyId);
        CompanyProfileData GetCompanyProfile(int companyId);
        List<UserProfileData> GetCompanyMembers(int companyId);
        // void EditCompany(EditCompanyData user);
    }
}
