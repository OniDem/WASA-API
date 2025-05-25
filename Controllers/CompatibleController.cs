using Microsoft.AspNetCore.Mvc;
using Services;
using WASA_CoreLib.Entity;
using WASA_DTOLib.Compatible;

namespace WASA_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CompatibleController : ControllerBase
    {
        private readonly CompatibleService _compatibleService;

        public CompatibleController(CompatibleService compatibleService)
        {
            _compatibleService = compatibleService;
        }

        [HttpPost]
        public async Task<ServerResponseEntity> Add(AddCompatibleRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _compatibleService.Add(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [HttpPost]
        public async Task<ServerResponseEntity> GetModelsByModelCodeRequest(GetModelsByModelCodeRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _compatibleService.GetModelsByModelCodeRequest(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [HttpPut]
        public async Task<ServerResponseEntity> Update(UpdateCompatibleRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _compatibleService.Update(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }
    }
}
