using System.Collections.Generic;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Interfaces
{
    public interface IFeedbackService
    {
        List<FeedbackDTO> GetAllFeedbackImages();
        bool SubmitImage(FeedbackImageData picture);
        List<FeedbackImage> GetUserFeedbackImages(int userId);
        List<FeedbackImage> GetCategoryFeedbackImages(int categoryId);
        FeedbackPost GetFeedbackPost(int feedbackPostId);
        void AddComment(FeedbackComment comment);
    }
}
