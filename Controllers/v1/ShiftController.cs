using Asp.Versioning;
using DTO.Shift;
using Microsoft.AspNetCore.Mvc;
using Services.v1;
using WASA_CoreLib.Entity;

namespace WASA_API.Controllers.v1
{
    [ApiVersion("1.0", Deprecated = false)]
    [ApiController]
    [Route("api/v{version:apiversion}/[controller]/[action]")]
    public class ShiftController : ControllerBase
    {
        private readonly ShiftService _shiftService;

        public ShiftController(ShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> OpenShift(OpenShiftRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _shiftService.OpenShift(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };

        }

        [MapToApiVersion("1.0")]
        [HttpPut]
        public async Task<ServerResponseEntity> CloseShift(CloseShiftRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _shiftService.CloseShift(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> ShowById(ShowByIdRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _shiftService.ShowById(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> ShowAll()
        {
            if (ModelState.IsValid)
            {
                var data = await _shiftService.ShowAll();
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("1.0")]
        [HttpPut]
        public async Task<ServerResponseEntity> AddReceiptToShift(AddReceiptToShiftRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _shiftService.AddReceiptToShift(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("1.0")]
        [HttpPut]
        public async Task<ServerResponseEntity> AcquiringApprove(AcquiringApproveRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _shiftService.AcquiringApprove(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }
    }
}
