using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using e_PhotoFeed.Services.Interfaces;

namespace f_PhotoFeed.WebApi.Controllers
{
    [RoutePrefix("api/searchpage")]
    public class SearchpageController : BaseApiController
    {
        private readonly ISearchpageService _searchpageService;

        public SearchpageController(ISearchpageService searchpageService)
        {
            _searchpageService = searchpageService;
        }

        [HttpGet]
        [Route("search")]
        public IHttpActionResult GetSearchResult([FromUri] List<string> tags)
        {
            var result = _searchpageService.GetPicturesBasedOnTags(tags);
            return Ok(result);
        }
    }
}
