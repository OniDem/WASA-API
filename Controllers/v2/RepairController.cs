using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.v2;
using WASA_CoreLib.Entity;
using WASA_DTOLib.Repair;

namespace WASA_API.Controllers.v2
{
    [ApiVersion("2.0", Deprecated = false)]
    [ApiController]
    [Authorize]
    [Route("api/v{version:apiversion}/[controller]/[action]")]
    public class RepairController : ControllerBase
    {
        private readonly RepairService _repairService;
        public RepairController(RepairService repairService)
        {
            _repairService = repairService;
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> AddRepair(AddRepairRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _repairService.AddRepairEntity(request);
                    return response;
                }
                return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
            }
            catch (Exception ex)
            {
                return new() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = "Ошибка на сервере" };
            } 
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> UpdateRepair(UpdateRepairRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _repairService.UpdateRepairEntity(request);
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> ShowRepairById(GetRepairByIdRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _repairService.ShowEntityById(request);
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> ShowAll()
        {
            if (ModelState.IsValid)
            {
                return await _repairService.ShowAllRepairs();
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }
    }
}
