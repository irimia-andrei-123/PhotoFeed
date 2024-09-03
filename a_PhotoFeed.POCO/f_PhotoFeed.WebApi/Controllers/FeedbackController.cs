using System.Web.Http;
using d_PhotoFeed.DTO;
using e_PhotoFeed.Services.Interfaces;

namespace f_PhotoFeed.WebApi.Controllers
{
    [RoutePrefix("api/feedback")]
    public class FeedbackController : BaseApiController
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult GetAllFeedback()
        {
            var result = _feedbackService.GetAllFeedbackImages();
            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddNewPicture([FromBody] FeedbackImageData photo)
        {
            return Ok(_feedbackService.SubmitImage(photo));
        }

        [HttpGet]
        [Route("posts/user/{userId}")]
        public IHttpActionResult GetUserPosts(int userId)
        {
            return Ok(_feedbackService.GetUserFeedbackImages(userId));
        }

        [HttpGet]
        [Route("posts/category/{categoryId}")]
        public IHttpActionResult GetCategoryPosts(int categoryId)
        {
            return Ok(_feedbackService.GetCategoryFeedbackImages(categoryId));
        }

        [HttpGet]
        [Route("posts/{feedbackPostId}")]
        public IHttpActionResult GetCategoryPost(int feedbackPostId)
        {
            return Ok(_feedbackService.GetFeedbackPost(feedbackPostId));
        }

        [HttpPost]
        [Route("comment")]
        public IHttpActionResult Comment([FromBody] FeedbackComment comment)
        {
            _feedbackService.AddComment(comment);
            return Ok();
        }

    }
}
