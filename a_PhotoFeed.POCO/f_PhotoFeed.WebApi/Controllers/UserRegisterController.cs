using System.Web.Http;
using d_PhotoFeed.DTO;
using e_PhotoFeed.Services.Interfaces;

namespace f_PhotoFeed.WebApi.Controllers
{
    [RoutePrefix("api/startpage")]
    public class UserRegisterController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserRegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register-user")]
        public IHttpActionResult AddNewUser([FromBody] CreateUserData newUser)
        {
            /*
             {
	            "IdUser": 1,
                "UserName": "User1",
                "Email": "User@email.com",
                "Password": "password",
                "Description": "",
                "ProfilePicture": "",
                "Verified": 1,
                "Points": 0,
                "Moderator": 1,
                "Blocked": 0
            }
            */
            return Ok(_userService.AddNewUser(newUser)); //return true if the user was created
        }

        [HttpPost]
        [Route("register-company")]
        public IHttpActionResult AddNewCompany([FromBody] CreateCompanyData newCompany)
        {
            /*
             {
                "IdCompany": 1,
                "CompanyName": "string",
                "Email": "string@email.com",
                "Password": "string",
                "Description": "",
                "ProfilePicture": "",
                "Members": [1, 2],
                "Allowed": 0
            }
            */
            return Ok(_userService.AddNewCompany(newCompany)); //return true if the user was created
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult LoginUser([FromBody] LoginInfo userLoginInfo)
        {
            /*{
                "Email": "User@email.com",
                "Password": "password"
            }*/
             return Ok(_userService.LoginUser(userLoginInfo)); //returns user's info if account exists
        }

        [HttpGet]
        [Route("leaderboard/{criteria}")]
        public IHttpActionResult GetLeaders(int criteria)
        {
            var result = _userService.GetTopUsers(criteria);
            return Ok(result);
        }

    }
}
