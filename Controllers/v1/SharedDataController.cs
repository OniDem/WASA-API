using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Services;
using WASA_CoreLib.Entity;
using WASA_DTOLib.SharedData;

namespace WASA_API.Controllers.v1
{
    [ApiVersion("1.0", Deprecated = false)]
    [ApiController]
    [Route("api/v{version:apiversion}/[controller]/[action]")]
    public class SharedDataController : ControllerBase
    {
        private readonly SharedDataService _sharedDataService;

        public SharedDataController(SharedDataService sharedDataService)
        {
            _sharedDataService = sharedDataService;
        }

        [MapToApiVersion("1.0")]
        [HttpPut]
        public async Task<ServerResponseEntity> Update(SharedDataRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _sharedDataService.Update(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> GetData(SharedDataRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _sharedDataService.GetData(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }
    }
}
