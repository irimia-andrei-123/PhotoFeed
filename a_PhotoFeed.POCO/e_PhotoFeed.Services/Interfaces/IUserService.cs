using System.Collections.Generic;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Interfaces
{
    public interface IUserService
    {
        UserProfileData GetUser(int userId);
        bool AddNewUser(CreateUserData newUser);
        bool AddNewCompany(CreateCompanyData newCompany);
        object LoginUser(LoginInfo userLoginInfo);
        List<LeaderInfo> GetTopUsers(int criteriaId);
        List<UserBaseInfo> GetAllForEmployees();
        List<UserDTO> GetAllUsers();
        void ChangeUserBlockStatus(int userId);
        List<string> GetProfileImages(int userId);
    }
}
