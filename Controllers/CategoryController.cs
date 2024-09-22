using Core.Entity;
using Microsoft.AspNetCore.Mvc;
using Services;
using WASA_CoreLib.ShowEntity;
using WASA_DTOLib.Category;

namespace WASA_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<List<CategoryShowEntity?>> GetAll()
        {
            if (ModelState.IsValid)
            {
                return await _categoryService.GetAll();
            }
            return null;
        }

        [HttpPost]
        public async Task<CategoryShowEntity> Add(AddCategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _categoryService.Add(request);
            }
            return null;
        }
    }
}
