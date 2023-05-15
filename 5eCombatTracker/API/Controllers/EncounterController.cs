using _5eCombatTracker.API.Interfaces;
using _5eCombatTracker.API.Services;
using _5eCombatTracker.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static _5eCombatTracker.Data.Enums;

namespace _5eCombatTracker.API.Controllers
{ 
    [ApiController]
    public class EncounterController : ControllerBase
    {
        private readonly IEncounterService _encounterService;
        public EncounterController(IEncounterService encounterService)
        {
            _encounterService = encounterService;
        }

        [HttpGet]
        [Route("random")]
        public async Task<IActionResult> GetRandomEncounter(BiomeTypeEnum biomeType = BiomeTypeEnum.Dungeon)
        {
            try
            {
                var responseData = await _encounterService.GetRandomEncounter(biomeType);
                if (responseData == null) { return StatusCode(StatusCodes.Status404NotFound); }
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
