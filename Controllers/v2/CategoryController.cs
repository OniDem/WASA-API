using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Services;
using WASA_CoreLib.Entity;
using WASA_DTOLib.Category;

namespace WASA_API.Controllers.v2
{
    [ApiVersion("2.0", Deprecated = false)]
    [ApiController]
    [Route("api/v{version:apiversion}/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> GetAll()
        {
            if (ModelState.IsValid)
            {
                var data = await _categoryService.GetAll();
                if(data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> Add(AddCategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _categoryService.Add(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        //[HttpDelete]
        //public async Task Delete(DeleteCategoryRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return _categoryService.Delete(request);
        //    }
        //}
    }
}
