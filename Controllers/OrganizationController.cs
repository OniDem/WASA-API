using DTO.Shift;
using Microsoft.AspNetCore.Mvc;
using Services;
using WASA_CoreLib.Entity;
using WASA_DTOLib.Organization;

namespace WASA_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrganizationController : ControllerBase
    {
        private readonly OrganizationService _organizationService;

        public OrganizationController(OrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpPost]
        public async Task<ServerResponseEntity> Create(AddOrganizationRequest request)
        {
            if(ModelState.IsValid)
            {
                var data = await _organizationService.Create(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [HttpPut]
        public async Task<ServerResponseEntity> AddBilling(AddBillingRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _organizationService.AddBilling(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [HttpPut]
        public async Task<ServerResponseEntity> AddStaff(AddStaffRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _organizationService.AddStaff(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [HttpPut]
        public async Task<ServerResponseEntity> AddShift(AddShiftRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _organizationService.AddShift(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [HttpPost]
        public async Task<ServerResponseEntity> ShowById(DTO.Shift.ShowByIdRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _organizationService.ShowById(new() { OrganizationId = request.Id });
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [HttpPost]
        public async Task<ServerResponseEntity> ShowAll()
        {
            if (ModelState.IsValid)
            {
                var data = await _organizationService.ShowAll();
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [HttpPost]
        public async Task<ServerResponseEntity> CashBoxOperation(CashBoxOperationRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _organizationService.CashBoxOperation(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }


        [HttpDelete]
        public void Delete(DeleteOrganizationRequest request)
        {
            if (ModelState.IsValid)
            {
                _organizationService.Delete(request);
            }
        }
    }
}
