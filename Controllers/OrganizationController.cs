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
        public async Task<OrganizationEntity?> Create(AddOrganizationRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _organizationService.Create(request);
            }
            return null;
        }

        [HttpPut]
        public async Task<OrganizationEntity?> AddBilling(AddBillingRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _organizationService.AddBilling(request);
            }
            return null;
        }

        [HttpPut]
        public async Task<OrganizationEntity?> AddStaff(AddStaffRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _organizationService.AddStaff(request);
            }
            return null;
        }

        [HttpPut]
        public async Task<OrganizationEntity?> AddShift(AddShiftRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _organizationService.AddShift(request);
            }
            return null;
        }

        [HttpPost]
        public async Task<OrganizationEntity?> ShowById(DTO.Shift.ShowByIdRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _organizationService.ShowById(new() { OrganizationId = request.Id });
            }
            return null;
        }

        [HttpPost]
        public async Task<IEnumerable<OrganizationEntity>?> ShowAll()
        {
            if (ModelState.IsValid)
            {
                return await _organizationService.ShowAll();
            }
            return null;
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
