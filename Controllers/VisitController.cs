using Microsoft.AspNetCore.Mvc;
using Services;
using WASA_CoreLib.Entity;
using WASA_DTOLib.Visit;
using DTO.Shift;

namespace WASA_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VisitController : ControllerBase
    {
        private readonly VisitService _visitService;

        public VisitController(VisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpPost]
        public async Task<VisitEntity?> Add(AddVisitRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _visitService.Add(request);
            }
            return null;
        }

        [HttpPost]
        public async Task<VisitEntity?> ShowById(DTO.Shift.ShowByIdRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _visitService.ShowById(new() {  Id = request.Id});
            }
            return null;
        }

        [HttpPost]
        public async Task<IEnumerable<VisitEntity>?> ShowAll()
        {
            if (ModelState.IsValid)
            {
                return await _visitService.ShowAll();
            }
            return null;
        }

        [HttpDelete]
        public void Delete(DeleteVisitRequest request)
        {
            if (ModelState.IsValid)
            {
                _visitService.Delete(request);
            }
        }
    }
}
