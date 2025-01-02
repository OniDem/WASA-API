using Core.Const;
using Core.Entity;
using DTO.Receipt;
using DTO.User;
using Microsoft.AspNetCore.Mvc;
using Services;
using WASA_CoreLib.Entity;
using WASA_DTOLib.Receipt;

namespace WASA_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReceiptController : ControllerBase
    {

        private readonly ReceiptService _receiptService;

        public ReceiptController(ReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

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
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [HttpPut]
        public async Task<ServerResponseEntity> Close([FromBody] GetReceiptByIdRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _receiptService.Close(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

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
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

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
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

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
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [HttpPost]
        public async Task<ServerResponseEntity> ShowById(GetReceiptByIdRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _receiptService.ShowById(request.Id);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

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
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

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
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

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
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }
    }
}
