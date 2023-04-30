using _5eCombatTracker.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _5eCombatTracker.API.Controllers
{
    [ApiController]
    public class BiomeTypeController : ControllerBase
    {
        private readonly IBiomeTypeService _biomeService;
        public BiomeTypeController(IBiomeTypeService biomeService)
        {
            _biomeService = biomeService;
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> GetAllBiomes()
        {
            try 
            { 
                var responseData = await _biomeService.GetAllBiomes();
                if (responseData == null) { return StatusCode(StatusCodes.Status404NotFound); }
                return Ok(responseData);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
