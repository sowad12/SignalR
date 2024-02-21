using Main.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SystemController : ControllerBase
    {
        private readonly ISystemManager _systemManager;
        public SystemController(ISystemManager systemManager)
        {
            _systemManager = systemManager;
        }
        [HttpPost("StoredProcedure")]
        public async Task<IActionResult> StoredProcedure()
        {
            var result = await _systemManager.StoredProcedure();
            return Ok(result);
        }

    }
}
