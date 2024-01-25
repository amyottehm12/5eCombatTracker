using _5eCombatTracker.API.Interfaces.Services;
using _5eCombatTracker.API.Services;
using _5eCombatTracker.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static _5eCombatTracker.Data.Enums;

namespace _5eCombatTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncounterController : ControllerBase
    {
        private readonly IEncounterService _encounterService;
        public EncounterController(IEncounterService encounterService)
        {
            _encounterService = encounterService;
        }

        /// <summary>
        /// Get random encounter by biome type
        /// </summary>
        /// <response code="200">Data retreived successfully</response>
        /// <response code="404">No data found</response>
        /// <response code="500">Something went wrong retrieving data</response>
        [HttpGet]
        [Route("random")]
        public async Task<IActionResult> GetRandomEncounter(BiomeTypeEnum biomeType = BiomeTypeEnum.Dungeon)
        {
            try
            {
                var responseData = await _encounterService.GetRandomEncounter(biomeType);
                if (responseData == null) { return NotFound(); }
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }
    }
}
