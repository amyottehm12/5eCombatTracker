using _5eCombatTracker.API.Interfaces;
using _5eCombatTracker.API.Services;
using _5eCombatTracker.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static _5eCombatTracker.Data.Enums;

namespace _5eCombatTracker.API.Controllers
{ 
    [ApiController]
    public class RandomEncounterController : ControllerBase
    {
        private readonly IEncounterService _encounterService;
        public RandomEncounterController(IEncounterService encounterService)
        {
            _encounterService = encounterService;
        }

        //BiomeTypes biome = BiomeTypes.Forest
        [HttpGet]
        [Route("api/[controller]/[action]/{BiomeTypes}")]
        public async Task<ActionResult<EncounterDTO>> GetRandomEncounter(BiomeTypeEnum BiomeTypes = BiomeTypeEnum.Dungeon)
        {
            try
            {
                var responseData = await _encounterService.GetRandomEncounter(BiomeTypes);
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
