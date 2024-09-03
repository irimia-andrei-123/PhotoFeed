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
    [RoutePrefix("api/contestPro")]
    public class ContestProController : BaseApiController
    {
        private readonly IContestProService _contestProService;

        public ContestProController(IContestProService contestProService)
        {
            _contestProService = contestProService;
        }

        [HttpPost]
        [Route("newContestPro")]
        public IHttpActionResult CreateContestPro([FromBody] ContestProDTO newContestPro)
        {
            return Ok(_contestProService.AddContest(newContestPro));
        }

        [HttpGet]
        [Route("{contestId}")]
        public IHttpActionResult GetContestPro(int contestId)
        {
            return Ok(_contestProService.GetContestPro(contestId));
        }

        [HttpGet]
        [Route("active")]
        public IHttpActionResult GetActiveContestPro()
        {
            var result = _contestProService.GetActiveContestsPro();
            return Ok(result);
        }

        [HttpGet]
        [Route("inactive")]
        public IHttpActionResult GetInactiveContestPro()
        {
            var result = _contestProService.GetInactiveContestsPro();
            return Ok(result);
        }

        [HttpPost]
        [Route("close/{contestId}")]
        public IHttpActionResult CloseContestPro(int contestId)
        {
            _contestProService.EndContest(contestId);
            return Ok();
        }
    }
}
