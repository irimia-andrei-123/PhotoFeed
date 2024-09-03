using System;
using System.Collections.Generic;
using System.Linq;
using a_PhotoFeed.POCO;
using AutoMapper;
using c_PhotoFeed.Repository.Interfaces;
using d_PhotoFeed.DTO;
using e_PhotoFeed.Services.Interfaces;

namespace e_PhotoFeed.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        private readonly IUnitOfWork _uow;

        public CategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<CategoryDTO> GetAllCategories()
        {
            return Mapper.Map<List<Category>,List<CategoryDTO>>(_uow.Categories.GetAll());
        }

        public List<CategoryImageUser> GetAllImagesFromCategory(int CategoryId)
        {
            var categoriesInfo = new List<CategoryImageUser>();
            var categories = _uow.PhotoUserCategories.Find(x => x.IdCategory == CategoryId).ToList();

            var posters = new List<User>();
            foreach (var category in categories)
            {
                var posterId = _uow.PhotoUsers.Find(x => x.IdPhotoUser == category.IdPhoto).Select(x => x.IdUser).FirstOrDefault();
                categoriesInfo.Add(new CategoryImageUser
                {
                    UserId = posterId,
                    ImageId = category.IdPhoto,
                    Username = _uow.Users.Find(x => x.IdUser == posterId).Select(x => x.UserName).FirstOrDefault(),
                    Image = _uow.PhotoUsers.Find(x => x.IdPhotoUser == category.IdPhoto).Select(x => x.Photo).FirstOrDefault(),
                    Category = _uow.Categories.Find(x => x.IdCategory==CategoryId).Select(x=>x.CategoryName).FirstOrDefault()
                });
            }

            return categoriesInfo;
        }
    }
}
