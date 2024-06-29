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
        public async Task<SharedDataEntity?> Update(SharedDataRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _sharedDataService.Update(request);
            }
            return null;
        }
    }
}
