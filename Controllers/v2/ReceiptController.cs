using Asp.Versioning;
using DTO.Receipt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.v2;
using WASA_CoreLib.Entity;
using WASA_DTOLib.General;
using WASA_DTOLib.Receipt;

namespace WASA_API.Controllers.v2
{
    [ApiVersion("2.0", Deprecated = false)]
    [ApiController]
    [Authorize]
    [Route("api/v{version:apiversion}/[controller]/[action]")]
    public class ReceiptController : ControllerBase
    {

        private readonly ReceiptService _receiptService;

        public ReceiptController(ReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> Add(AddReceiptRequest request)
        {
            if (ModelState.IsValid)
            {
                var data =  await _receiptService.Add(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("2.0")]
        [HttpPut]
        public async Task<ServerResponseEntity> Close([FromBody] ShowByIdRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _receiptService.Close(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("2.0")]
        [HttpPut]
        public async Task<ServerResponseEntity> Payment(PaymentReceiptRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _receiptService.Payment(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("2.0")]
        [HttpPut]
        public async Task<ServerResponseEntity> Cancel(CancelReceiptRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _receiptService.Cancel(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("2.0")]
        [HttpPut]
        public async Task<ServerResponseEntity> AddProducts(AddProductToReceiptRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _receiptService.AddProducts(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> ShowById(ShowByIdRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _receiptService.ShowById(request.Id);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> ShowCreatedByDate(ShowReceiptByDateRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _receiptService.ShowCreatedByDate(request.Date!.Value);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> ShowClosedByDate(ShowReceiptByDateRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _receiptService.ShowClosedByDate(request.Date!.Value);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> ShowPaymentByDate(ShowReceiptByDateRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _receiptService.ShowPaymentByDate(request.Date!.Value);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = "Были отправлены некорректные данные" };
        }
    }
}
