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
    [RoutePrefix("api/upload")]
    public class ImageController : BaseApiController
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        [Route("newPicture")]
        public IHttpActionResult UploadUserPicture([FromBody] UploadImage photo)
        {
            return Ok(_imageService.UploadUserImage(photo));
        }

        [HttpGet]
        [Route("post/{postId}")]
        public IHttpActionResult GetPost(int postId)
        {
            return Ok(_imageService.GetPost(postId));
        }

        [HttpPost]
        [Route("submitBasicContest")]
        public IHttpActionResult SubmitBasicContest([FromBody] ContestSubmissionImages photos)
        {
            _imageService.SubmitBasicContestImages(photos);
            return Ok();
        }

        [HttpGet]
        [Route("submissions/{contestBasicId}/{criteria}")]
        public IHttpActionResult GetContestBasicSubmissions(int contestBasicId, bool criteria)
        {
            var result = _imageService.GetContestBasicSubmissions(contestBasicId, criteria);
            return Ok(result);
        }

        [HttpPut]
        [Route("voteBasic/{submissionId}/{points}")]
        public IHttpActionResult SubmitVoteBasic(int submissionId, int points)
        {
            _imageService.SubmitVoteBasic(submissionId, points);
            return Ok();
        }

        [HttpPost]
        [Route("submitProContest")]
        public IHttpActionResult submitProContest([FromBody] ContestSubmissionImages photos)
        {
            _imageService.SubmitProContestImages(photos);
            return Ok();
        }

        [HttpGet]
        [Route("submissionsPro/{contestProId}/{criteria}")]
        public IHttpActionResult GetContestProSubmissions(int contestProId, bool criteria)
        {
            var result = _imageService.GetContestProSubmissions(contestProId, criteria);
            return Ok(result);
        }

        [HttpPut]
        [Route("votePro/{submissionId}/{points}")]
        public IHttpActionResult SubmitVotePro(int submissionId, int points)
        {
            _imageService.SubmitVotePro(submissionId, points);
            return Ok();
        }
    }
}
