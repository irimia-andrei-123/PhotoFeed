using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Interfaces
{
    public interface IImageService
    {
        int UploadUserImage(UploadImage picture);
        ImageInfo GetPost(int imageId);
        void SubmitBasicContestImages(ContestSubmissionImages photos);
        List<PhotoBasicContestDTO> GetContestBasicSubmissions(int contestBasicId, bool criteria);
        void SubmitVoteBasic(int submissionId, int points);
        void SubmitProContestImages(ContestSubmissionImages photos);
        List<PhotoProContestDTO> GetContestProSubmissions(int contestProId, bool criteria);
        void SubmitVotePro(int submissionId, int points);
    }
}
