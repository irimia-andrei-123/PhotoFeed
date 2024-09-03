using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using e_PhotoFeed.Services.Interfaces;

namespace f_PhotoFeed.WebApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getAllForEmployees")]
        public IHttpActionResult GetAllForEmployees()
        {
            var result = _userService.GetAllForEmployees();
            return Ok(result);
        }

        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult GetAll()
        {
            var result = _userService.GetAllUsers();
            return Ok(result);
        }

        [HttpPut]
        [Route("changeBlockStatus/{userId}")]
        public IHttpActionResult ChangeUserBlockStatus(int userId)
        {
            _userService.ChangeUserBlockStatus(userId);
            return Ok();
        }

        [HttpGet]
        [Route("get/{userId}")]
        public IHttpActionResult Get(int userId)
        {
            var result = _userService.GetUser(userId);
            return Ok(result);
        }

        [HttpGet]
        [Route("getProfileImages/{userId}")]
        public IHttpActionResult GetProfileImages(int userId)
        {
            var result = _userService.GetProfileImages(userId);
            return Ok(result);
        }
    }

}