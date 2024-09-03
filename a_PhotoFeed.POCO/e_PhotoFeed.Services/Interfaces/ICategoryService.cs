using System.Collections.Generic;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryDTO> GetAllCategories();
        List<CategoryImageUser> GetAllImagesFromCategory(int CategoryId);
    }
}
