using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using d_PhotoFeed.DTO;
using e_PhotoFeed.Services.Interfaces;

namespace f_PhotoFeed.WebApi.Controllers
{

    [RoutePrefix("api/contestBasic")]
    public class ContestBasicController : BaseApiController
    {
        private readonly IContestBasicService _contestBasicService;

        public ContestBasicController(IContestBasicService contestBasicService)
        {
            _contestBasicService = contestBasicService;
        }

        [HttpPost]
        [Route("newContestBasic")]
        public IHttpActionResult CreateContestBasic([FromBody] ContestBasicDTO newContestBasic)
        {
            return Ok(_contestBasicService.AddContest(newContestBasic));
        }

        [HttpGet]
        [Route("{contestId}")]
        public IHttpActionResult GetContestBasic(int contestId)
        {
            return Ok(_contestBasicService.GetContestBasic(contestId));
        }

        [HttpGet]
        [Route("active")]
        public IHttpActionResult GetActiveContestBasic()
        {
            var result = _contestBasicService.GetActiveContestsBasic();
            return Ok(result);
        }

        [HttpGet]
        [Route("inactive")]
        public IHttpActionResult GetInactiveContestBasic()
        {
            var result = _contestBasicService.GetInactiveContestsBasic();
            return Ok(result);
        }

        [HttpPost]
        [Route("close/{contestId}")]
        public IHttpActionResult CloseContestBasic(int contestId)
        {
            _contestBasicService.EndContest(contestId);
            return Ok();
        }

    }
}
