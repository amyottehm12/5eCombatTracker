using _5eCombatTracker.API.Interfaces;
using _5eCombatTracker.Data.DTO;
using Microsoft.AspNetCore.Mvc;
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
        public EncounterDTO GetRandomEncounter(BiomeTypeEnum BiomeTypes = BiomeTypeEnum.Dungeon)
        {
            return _encounterService.GetRandomEncounter(BiomeTypes);
        }
    }
}
