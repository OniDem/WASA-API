using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Services;
using WASA_CoreLib.Entity;
using WASA_DTOLib.Compatible;

namespace WASA_API.Controllers.v1
{
    [ApiVersion("1.0", Deprecated = false)]
    [ApiController]
    [Route("api/v{version:apiversion}/[controller]/[action]")]
    public class CompatibleController : ControllerBase
    {
        private readonly CompatibleService _compatibleService;

        public CompatibleController(CompatibleService compatibleService)
        {
            _compatibleService = compatibleService;
        }

        [MapToApiVersion("1.0")]
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

        [MapToApiVersion("1.0")]
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

        [MapToApiVersion("1.0")]
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
