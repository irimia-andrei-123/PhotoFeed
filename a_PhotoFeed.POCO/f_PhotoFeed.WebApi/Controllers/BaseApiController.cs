using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using f_PhotoFeed.WebApi.Filters;

namespace f_PhotoFeed.WebApi.Controllers
{
    [PhotoFeedExceptionAttribute]
    public class BaseApiController : ApiController
    {
    }
}
