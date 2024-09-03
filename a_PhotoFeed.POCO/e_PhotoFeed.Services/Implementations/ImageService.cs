using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using a_PhotoFeed.POCO;
using AutoMapper;
using c_PhotoFeed.Repository.Interfaces;
using d_PhotoFeed.DTO;
using e_PhotoFeed.Services.Interfaces;

namespace e_PhotoFeed.Services.Implementations
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _uow;

        public ImageService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public int UploadUserImage(UploadImage picture)
        {
            //add img to db
            var pictureInfo = Mapper.Map<PhotoUserDTO, PhotoUser>(new PhotoUserDTO()
            {
                IdUser = picture.IdUser,
                Copyrighted = picture.Copyrighted,
                Photo = picture.Photo,
                Description = picture.Description,
                DatePosted = picture.DatePosted,
                Rating = picture.Rating
            });
            _uow.PhotoUsers.Add(pictureInfo);
            _uow.PhotoUsers.Save();

            //add categories
            foreach (var category in picture.Categories)
            {
                var categoryInfo = Mapper.Map<PhotoUserCategoryDTO, PhotoUserCategory>(new PhotoUserCategoryDTO()
                {
                    IdCategory = category,
                    IdPhoto = pictureInfo.IdPhotoUser
                });
                _uow.PhotoUserCategories.Add(categoryInfo);
            }
            _uow.PhotoUserCategories.Save();

            //add tags if they don't exist and get tag ids
            List<int> tagIds = new List<int>();
            foreach (var tag in picture.Tags)
            {
                var findTag = _uow.Tags.Find(x => x.TagName == tag).FirstOrDefault();
                if (findTag == null)
                {
                    var newTag = Mapper.Map<TagDTO, Tag>(new TagDTO()
                    {
                        TagName = tag
                    });
                    _uow.Tags.Add(newTag);
                    _uow.Tags.Save();
                    tagIds.Add(newTag.IdTag);
                }
                else
                {
                    tagIds.Add(findTag.IdTag);
                }
            }

            //add photoTags
            foreach (var tagId in tagIds)
            {
                var tagInfo = Mapper.Map<PhotoTagDTO, PhotoTag>(new PhotoTagDTO()
                {
                    IdTag = tagId,
                    IdPhoto = pictureInfo.IdPhotoUser
                });
                _uow.PhotoTags.Add(tagInfo);
            }
            _uow.PhotoTags.Save();

            return pictureInfo.IdPhotoUser;
        }

        public ImageInfo GetPost(int imageId)
        {
            var imageInfo = _uow.PhotoUsers.Where(x => x.IdPhotoUser == imageId).FirstOrDefault();
            var userInfo = _uow.Users.Where(x => x.IdUser == imageInfo.IdUser).FirstOrDefault();

            ImageInfo post = new ImageInfo()
            {
                IdPhoto = imageId,
                Photo = imageInfo.Photo,
                IdUser = userInfo.IdUser,
                UserName = userInfo.UserName,
                UserPicture = userInfo.ProfilePicture,
                Description = imageInfo.Description,
                DatePosted = imageInfo.DatePosted,
                Rating = imageInfo.Rating
            };

            return post;
        }

        public void SubmitBasicContestImages(ContestSubmissionImages photos)
        {
            foreach (var picture in photos.Photos)
            {
                _uow.PhotoBasicContests.Add(Mapper.Map<PhotoBasicContestDTO, PhotoBasicContest>(
                    new PhotoBasicContestDTO()
                    {
                        Copyrighted = 1,
                        DatePosted = DateTime.Now,
                        IdBasicContest = photos.IdContest,
                        IdUser = photos.IdUser,
                        Photo = picture,
                        Rating = 0
                    }));
            }
            _uow.PhotoBasicContests.Save();
        }

        public List<PhotoBasicContestDTO> GetContestBasicSubmissions(int contestBasicId, bool criteria)
        {
            if (!criteria)
            {
                return Mapper.Map<List<PhotoBasicContest>,List<PhotoBasicContestDTO>>(_uow.PhotoBasicContests.Where(x => x.IdBasicContest == contestBasicId).OrderBy(x => x.DatePosted).ToList());
            }
            else
            {
                return Mapper.Map<List<PhotoBasicContest>, List<PhotoBasicContestDTO>>(_uow.PhotoBasicContests.Where(x => x.IdBasicContest == contestBasicId).OrderByDescending(x => x.Rating).ToList());
            }
        }

        public void SubmitVoteBasic(int submissionId, int points)
        {
            var submission = _uow.PhotoBasicContests.Where(x => x.IdPhotoBasicContest == submissionId).SingleOrDefault();
            submission.Rating = submission.Rating + points;
            _uow.PhotoBasicContests.Save();
        }

        public void SubmitProContestImages(ContestSubmissionImages photos)
        {
            foreach (var picture in photos.Photos)
            {
                _uow.PhotoProContests.Add(Mapper.Map<PhotoProContestDTO, PhotoProContest>(
                    new PhotoProContestDTO()
                    {
                        Copyrighted = 1,
                        DatePosted = DateTime.Now,
                        IdProContest = photos.IdContest,
                        IdUser = photos.IdUser,
                        Photo = picture,
                        Rating = 0
                    }));
            }
            _uow.PhotoProContests.Save();
        }

        public List<PhotoProContestDTO> GetContestProSubmissions(int contestProId, bool criteria)
        {
            if (!criteria)
            {
                return Mapper.Map<List<PhotoProContest>, List<PhotoProContestDTO>>(_uow.PhotoProContests.Where(x => x.IdProContest == contestProId).OrderBy(x => x.DatePosted).ToList());
            }
            else
            {
                return Mapper.Map<List<PhotoProContest>, List<PhotoProContestDTO>>(_uow.PhotoProContests.Where(x => x.IdProContest == contestProId).OrderByDescending(x => x.Rating).ToList());
            }
        }

        public void SubmitVotePro(int submissionId, int points)
        {
            var submission = _uow.PhotoProContests.Where(x => x.IdPhotoProContest == submissionId).SingleOrDefault();
            submission.Rating = submission.Rating + points;
            _uow.PhotoProContests.Save();
        }
    }
}
