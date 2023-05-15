using _5eCombatTracker.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _5eCombatTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiomeTypeController : ControllerBase
    {
        private readonly IBiomeTypeService _biomeService;
        public BiomeTypeController(IBiomeTypeService biomeService)
        {
            _biomeService = biomeService;
        }

        /// <summary>
        /// Retrieves all biome types as a string list
        /// </summary>
        /// <response code="200">Biome types retreived successfully</response>
        /// <response code="404">No biome types found</response>
        /// <response code="500">Something went wrong retrieving biome types</response>
        [HttpGet]
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
