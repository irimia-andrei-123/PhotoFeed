using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using a_PhotoFeed.POCO;
using AutoMapper;
using c_PhotoFeed.Repository.Interfaces;
using d_PhotoFeed.DTO;
using e_PhotoFeed.Services.Exceptions;
using e_PhotoFeed.Services.Interfaces;

namespace e_PhotoFeed.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public UserProfileData GetUser(int userId)
        {
            var userProfileData = new UserProfileData();
            var user = _uow.Users.Find(x => x.IdUser == userId).FirstOrDefault();
            userProfileData.IdUser = user.IdUser;
            userProfileData.UserName = user.UserName;
            userProfileData.Email = user.Email;
            userProfileData.Description = user.Description;
            userProfileData.ProfilePicture = user.ProfilePicture;
            userProfileData.Points = user.Points;
            userProfileData.Blocked = user.Blocked;
            userProfileData.Contact = Mapper.Map<List<UserContact>,List<UserContactDTO>>(_uow.UserContacts.Where(x => x.IdContactUser == userId).ToList());
            return userProfileData;
        }

        public bool AddNewUser(CreateUserData newUser)
        {
            if (!_uow.Users.Exists(x => x.Email == newUser.Email))
            {
                var userData = new UserDTO()
                {
                    IdUser = newUser.IdUser,
                    UserName = newUser.UserName,
                    Email = newUser.Email,
                    Password = newUser.Password,
                    Description = newUser.Description,
                    ProfilePicture = newUser.ProfilePicture,
                    Verified = newUser.Verified,
                    Points = newUser.Points,
                    Moderator = newUser.Moderator,
                    Blocked = newUser.Blocked
                };

                _uow.Users.Add(Mapper.Map<UserDTO, User>(userData));

                try
                {
                    _uow.Users.Save();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        var x =("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            var y =("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

                foreach (var contact in newUser.ContactInfo)
                {
                    UserContactDTO ucd = new UserContactDTO()
                    {
                        IdContactUser = _uow.Users.Where(x => x.Email == newUser.Email).Select(x => x.IdUser).SingleOrDefault(),
                        IdContact = 0,
                        WebsiteName = contact.WebsiteName,
                        WebsiteUrl = contact.WebsiteUrl
                    };
                    _uow.UserContacts.Add(Mapper.Map<UserContactDTO, UserContact>(ucd));
                }
                _uow.UserContacts.Save();

                return true;
            }
            else
                throw new AccountExistsException("there already is an account using this email");
        }

        public bool AddNewCompany(CreateCompanyData newCompany)
        {
            //check unique email
            if (!_uow.Companies.Exists(x => x.Email == newCompany.Email))
            {
                _uow.Companies.Add(new Company()
                {
                    Allowed = newCompany.Allowed,
                    Password = newCompany.Password,
                    Email = newCompany.Email,
                    Description = newCompany.Description,
                    CompanyName = newCompany.CompanyName,
                    ProfilePicture = newCompany.ProfilePicture
                });
                try
                {
                    _uow.Companies.Save();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        var x = ("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            var y = ("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                foreach (var member in newCompany.Members)
                {
                    _uow.CompanyMembers.Add(new CompanyMember()
                    {
                        IdUser = member,
                        IdCompany = _uow.Companies.Where(x => x.Email == newCompany.Email).Select(x => x.IdCompany).FirstOrDefault()
                    });
                }
                _uow.CompanyMembers.Save();

                foreach (var contact in newCompany.ContactInfo)
                {
                    CompanyContactDTO ccd = new CompanyContactDTO()
                    {
                        IdContactCompany = _uow.Companies.Where(x => x.Email == newCompany.Email).Select(x => x.IdCompany).SingleOrDefault(),
                        IdContact = 0,
                        WebsiteName = contact.WebsiteName,
                        WebsiteUrl = contact.WebsiteUrl
                    };
                    _uow.CompanyContacts.Add(Mapper.Map<CompanyContactDTO, CompanyContact>(ccd));
                }
                _uow.CompanyContacts.Save();

                return true;
            }
            else
                throw new AccountExistsException("there already is an account using this email");
        }

        public object LoginUser(LoginInfo userLoginInfo)
        {
            if (_uow.Users.Exists(x => (x.Email == userLoginInfo.Email) && (x.Password == userLoginInfo.Password) && (x.Blocked == 0)))
                return Mapper.Map<User, UserDTO>(_uow.Users.Find(x => (x.Email == userLoginInfo.Email) && (x.Password == userLoginInfo.Password) && (x.Blocked == 0)).SingleOrDefault());
            else
                if (_uow.Companies.Exists(x => (x.Email == userLoginInfo.Email) && (x.Password == userLoginInfo.Password) && (x.Allowed == 1)))
                    return Mapper.Map<Company, CompanyDTO>(_uow.Companies.Find(x => (x.Email == userLoginInfo.Email) && (x.Password == userLoginInfo.Password) && (x.Allowed == 1)).SingleOrDefault());
                else
                    throw new BadLoginCredentialsException("No user with the specified credentials or account blocked");
        }

        public List<LeaderInfo> GetTopUsers(int criteriaId)
        {

            switch (criteriaId)
            {
                case 0:
                {
                    var users = _uow.Users.OrderByDescending(x => x.Points).Take(10).Select(x => x.IdUser).ToList();
                    var proContestsWon = _uow.WinnerProes.Where(x => users.Contains(x.IdWinnerUser)).Count();
                    var basicContestsWon = _uow.WinnerBasics.Where(x => users.Contains(x.IdWinnerUser)).Count();

                    List<LeaderInfo> topUserData = new List<LeaderInfo>();
                    int i = 1;
                    foreach (var user in users)
                    {
                        topUserData.Add(new LeaderInfo()
                        {
                            UserId = _uow.Users.Find(x => x.IdUser == user).Select(x => x.IdUser).FirstOrDefault(),
                            Position = i++,
                            Username = _uow.Users.Find(x => x.IdUser == user).Select(x => x.UserName).FirstOrDefault(),
                            Points = _uow.Users.Find(x => x.IdUser == user).Select(x => x.Points).FirstOrDefault(),
                            ProContestsWon = _uow.WinnerProes.Where(x => user == x.IdWinnerUser).Count(),
                            BasicContestsWon = _uow.WinnerBasics.Where(x => user == x.IdWinnerUser).Count(),
                        });
                    }

                    return topUserData;
                }

                case 1:
                {
                    var allUsers = _uow.WinnerProes.Find(x => x.PositionPlaced == 1).Select(x => x.IdWinnerUser).ToList();
                    Hashtable numberOfWins = new Hashtable();
                    foreach (var user in allUsers)
                    {
                        var wins = allUsers.FindAll(x => x == user).Count();
                        if (!numberOfWins.ContainsKey(user))
                            numberOfWins[user] = wins;
                    }

                    var users = numberOfWins.Cast<DictionaryEntry>().OrderByDescending(entry => entry.Value).Select(x => x.Key).Take(10).ToList();

                    List<LeaderInfo> topUserData = new List<LeaderInfo>();
                    int i = 1;
                    foreach (int user in users)
                    {
                        topUserData.Add(new LeaderInfo()
                        {
                            UserId = _uow.Users.Find(x => x.IdUser == user).Select(x => x.IdUser).FirstOrDefault(),
                            Position = i++,
                            Username = _uow.Users.Find(x => x.IdUser == user).Select(x => x.UserName).FirstOrDefault(),
                            Points = _uow.Users.Find(x => x.IdUser == user).Select(x => x.Points).FirstOrDefault(),
                            ProContestsWon = _uow.WinnerProes.Where(x => user == x.IdWinnerUser).Count(),
                            BasicContestsWon = _uow.WinnerBasics.Where(x => user == x.IdWinnerUser).Count(),
                        });
                    }

                    return topUserData;
                }

                case 2:
                {
                    var allUsers = _uow.WinnerBasics.Find(x => x.PositionPlaced == 1).Select(x => x.IdWinnerUser).ToList();
                        Hashtable numberOfWins = new Hashtable();
                    foreach (var user in allUsers)
                    {
                        var wins = allUsers.FindAll(x => x == user).Count();
                        if (!numberOfWins.ContainsKey(user))
                            numberOfWins[user] = wins;
                    }

                    var users = numberOfWins.Cast<DictionaryEntry>().OrderByDescending(entry => entry.Value).Select(x => x.Key).Take(10).ToList();

                    List<LeaderInfo> topUserData = new List<LeaderInfo>();
                    int i = 1;
                    foreach (int user in users)
                    {
                        topUserData.Add(new LeaderInfo()
                        {
                            UserId = _uow.Users.Find(x => x.IdUser == user).Select(x => x.IdUser).FirstOrDefault(),
                            Position = i++,
                            Username = _uow.Users.Find(x => x.IdUser == user).Select(x => x.UserName).FirstOrDefault(),
                            Points = _uow.Users.Find(x => x.IdUser == user).Select(x => x.Points).FirstOrDefault(),
                            ProContestsWon = _uow.WinnerProes.Where(x => user == x.IdWinnerUser).Count(),
                            BasicContestsWon = _uow.WinnerBasics.Where(x => user == x.IdWinnerUser).Count(),
                        });
                    }

                    return topUserData;
                }

                default:
                    return null;
            }
        }

        public List<UserBaseInfo> GetAllForEmployees()
        {
            return _uow.Users.GetAll().Select(x => new UserBaseInfo() { IdUser = x.IdUser, UserName = x.UserName} ).ToList();
        }

        public List<UserDTO> GetAllUsers()
        {
            var users = _uow.Users.GetAll().Where(x => x.Email != "admin@admin.com").ToList();
            return Mapper.Map<List<User>, List<UserDTO>>(users);
        }

        public void ChangeUserBlockStatus(int userId)
        {
            var user = _uow.Users.Where(x => x.IdUser == userId).SingleOrDefault();
            user.Blocked = user.Blocked == 1 ? 0 : 1;
            _uow.Users.Save();
        }

        public List<string> GetProfileImages(int userId)
        {
            return _uow.PhotoUsers.Where(x => x.IdUser == userId).OrderBy(x => x.DatePosted).Select(x => x.Photo).ToList();
        }
    }
}
