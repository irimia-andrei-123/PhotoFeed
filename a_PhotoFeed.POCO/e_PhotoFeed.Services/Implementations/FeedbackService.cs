using System.Collections.Generic;
using System.Linq;
using a_PhotoFeed.POCO;
using AutoMapper;
using c_PhotoFeed.Repository.Interfaces;
using d_PhotoFeed.DTO;
using e_PhotoFeed.Services.Interfaces;

namespace e_PhotoFeed.Services.Implementations
{
    class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _uow;

        public FeedbackService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<FeedbackDTO> GetAllFeedbackImages()
        {
            return Mapper.Map<List<Feedback>, List<FeedbackDTO>>(_uow.Feedbacks.GetAll());
        }

        public bool SubmitImage(FeedbackImageData picture)
        {
            var pictureInfo = Mapper.Map<PhotoFeedbackDTO, PhotoFeedback>(new PhotoFeedbackDTO()
            {
                IdUser = picture.IdUser,
                Copyrighted = picture.Copyrighted,
                Photo = picture.Photo,
                Description = picture.Description,
                DatePosted = picture.DatePosted
            });
            _uow.PhotoFeedbacks.Add(pictureInfo);

            var pictureCategory = new PhotoFeedbackCategoryDTO()
            {
                IdCategory = picture.CategoryId,
                IdPhoto = pictureInfo.IdPhotoFeedback
            };
            _uow.PhotoFeedbackCategories.Add(Mapper.Map<PhotoFeedbackCategoryDTO, PhotoFeedbackCategory>(pictureCategory));

            _uow.PhotoFeedbacks.Save();
            _uow.PhotoFeedbackCategories.Save();
            return true;
        }

        public List<FeedbackImage> GetUserFeedbackImages(int userId)
        {
            var basePhotos = _uow.PhotoFeedbacks.Where(x => x.IdUser == userId).OrderByDescending(x => x.IdPhotoFeedback);
            var userName = _uow.Users.Find(x => x.IdUser == userId).Select(x => x.UserName).FirstOrDefault();
            List<FeedbackImage> photos = new List<FeedbackImage>();
            foreach (var photo in basePhotos)
            {
                photos.Add(new FeedbackImage()
                {
                    IdPhotoFeedback = photo.IdPhotoFeedback,
                    Photo = photo.Photo,
                    IdUser = photo.IdUser,
                    UserName = userName,
                    Description = photo.Description,
                    DatePosted = photo.DatePosted
                });
            }

            return photos;
        }

        public List<FeedbackImage> GetCategoryFeedbackImages(int categoryId)
        {
            var photoIds = _uow.PhotoFeedbackCategories.Where(x => x.IdCategory == categoryId).OrderByDescending(x => x.IdPhoto).Select(x => x.IdPhoto);
            List<FeedbackImage> photos = new List<FeedbackImage>();
            foreach (var photoId in photoIds)
            {
                var photoInfo = _uow.PhotoFeedbacks.Find(x => x.IdPhotoFeedback == photoId).FirstOrDefault();
                var userName = _uow.Users.Find(x => x.IdUser == photoInfo.IdUser).Select(x => x.UserName).FirstOrDefault();
                photos.Add(new FeedbackImage()
                {
                    IdPhotoFeedback = photoInfo.IdPhotoFeedback,
                    Photo = photoInfo.Photo,
                    IdUser = photoInfo.IdUser,
                    IdImage = photoInfo.IdPhotoFeedback,
                    UserName = userName,
                    Description = photoInfo.Description,
                    DatePosted = photoInfo.DatePosted
                });
            }

            return photos;
        }

        public FeedbackPost GetFeedbackPost(int feedbackPostId)
        {
            var feedbackImage = _uow.PhotoFeedbacks.Where(x => x.IdPhotoFeedback == feedbackPostId).FirstOrDefault();
            var feedbackUser = _uow.Users.Where(x => x.IdUser == feedbackImage.IdUser).FirstOrDefault();
            var feedbackComments = _uow.Feedbacks.Where(x => x.IdPhotoFeedback == feedbackPostId).ToArray();
            List<FeedbackComment> comments = new List<FeedbackComment>();
            foreach (var feedbackComment in feedbackComments)
            {
                string username = _uow.Users.Where(x => x.IdUser == feedbackComment.IdCommenter).Select(x => x.UserName)
                    .SingleOrDefault();
                FeedbackComment comment = new FeedbackComment()
                {
                    IdCommenter = feedbackComment.IdCommenter,
                    IdPhotoFeedback = feedbackComment.IdPhotoFeedback,
                    Miscellaneous = feedbackComment.Miscellaneous,
                    DatePosted = feedbackComment.DatePosted,
                    CommenterName = username
                };
                comments.Add(comment);
            }

            FeedbackPost feedbackPost = new FeedbackPost()
            {
                IdPhotoFeedback = feedbackImage.IdPhotoFeedback,
                Photo = feedbackImage.Photo,
                IdUser = feedbackImage.IdUser,
                UserName = feedbackUser.UserName,
                Description = feedbackImage.Description,
                DatePosted = feedbackImage.DatePosted,
                Comments = comments
            };

            return feedbackPost;
        }

        public void AddComment(FeedbackComment comment)
        {
            var feedbackComment = new FeedbackDTO()
            {
                IdCommenter = comment.IdCommenter,
                IdPhotoFeedback = comment.IdPhotoFeedback,
                GoodParts = "x",
                BadParts = "x",
                Miscellaneous = comment.Miscellaneous,
                DatePosted = comment.DatePosted,
                Rating = 1
            };

            _uow.Feedbacks.Add(Mapper.Map<FeedbackDTO, Feedback>(feedbackComment));
            _uow.Feedbacks.Save();
        }
    }
}
