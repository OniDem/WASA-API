using Microsoft.AspNetCore.Mvc;
using Services;
using WASA_CoreLib.Entity;
using WASA_DTOLib.SharedData;

namespace WASA_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SharedDataController : ControllerBase
    {
        private readonly SharedDataService _sharedDataService;

        public SharedDataController(SharedDataService sharedDataService)
        {
            _sharedDataService = sharedDataService;
        }

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
