using System.Web.Http;
using e_PhotoFeed.Services.Interfaces;

namespace f_PhotoFeed.WebApi.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService= categoryService;
        }

        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult GetAllCategories()
        {
            var result = _categoryService.GetAllCategories();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetCategory/{categoryId}")]
        public IHttpActionResult GetCategoryImages(int categoryId)
        {
            var result = _categoryService.GetAllImagesFromCategory(categoryId);
            return Ok(result);
        }

    }
}
