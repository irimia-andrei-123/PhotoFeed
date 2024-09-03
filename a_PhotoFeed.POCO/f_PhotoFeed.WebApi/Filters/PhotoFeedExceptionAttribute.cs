using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace f_PhotoFeed.WebApi.Filters
{
    public class PhotoFeedExceptionAttribute: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext ctx)
        {
            //base.OnException(ctx);
            var responseMessage = string.Format(
                "Error thrown by execution logic. Message: {0}", ctx.Exception.Message);

            ctx.Response = ctx.Request.CreateResponse(HttpStatusCode.NotAcceptable, responseMessage);
        }
    }
}