using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_PhotoFeed.Repository.Interfaces;
using d_PhotoFeed.DTO;
using e_PhotoFeed.Services.Interfaces;

namespace e_PhotoFeed.Services.Implementations
{
    class SearchpageService : ISearchpageService
    {
        private readonly IUnitOfWork _uow;

        public SearchpageService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<SearchImage> GetPicturesBasedOnTags(List<string> tags)
        {
            //gets the ids of the tags
            var tagIds = _uow.Tags.Where(x => tags.Contains(x.TagName)).Select(x => x.IdTag).ToList();
            //gets all images with the specified tags (duplocates can appear)
            var pictureIds = _uow.PhotoTags.Where(x => tagIds.Contains(x.IdTag)).Select(x => x.IdPhoto).ToList();
            //hashtable with no of apparitions
            Dictionary<int,int> imageFrequency = new Dictionary<int, int>();
            foreach (var picture in pictureIds){
                if (imageFrequency.ContainsKey(picture))
                    imageFrequency[picture] = imageFrequency[picture] + 1;
                else
                    imageFrequency.Add(picture,1);
            }

            var max = 0;
            foreach (var key in imageFrequency.Keys)
            {
                if (imageFrequency[key] > max)
                    max = imageFrequency[key];
            }

            List<int> resultImageIds = new List<int>();
            foreach (var key in imageFrequency.Keys)
            {
                if (imageFrequency[key] == max)
                    resultImageIds.Add(key);
            }

            List<SearchImage> photos = new List<SearchImage>();

            foreach (var image in resultImageIds)
            {
                var photoInfo = _uow.PhotoUsers.Find(x => x.IdPhotoUser == image).FirstOrDefault();
                var userName = _uow.Users.Find(x => x.IdUser == photoInfo.IdUser).Select(x => x.UserName).FirstOrDefault();
                photos.Add(new SearchImage()
                {
                    ImageId = photoInfo.IdPhotoUser,
                    UserId = photoInfo.IdUser,
                    Username = userName,
                    Image = photoInfo.Photo
                });
            }

            return photos;
        }
    }
}
