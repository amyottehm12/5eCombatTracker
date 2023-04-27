using Microsoft.AspNetCore.Mvc;
using static _5eCombatTracker.Data.Enums;

namespace _5eCombatTracker.API.Controllers
{ 
    [ApiController]
    public class RandomEncounterController : ControllerBase
    {

        public RandomEncounterController()
        {
            
        }

        //BiomeTypes biome = BiomeTypes.Forest
        [HttpGet]
        [Route("api/[controller]/[action]/{BiomeTypes}")]
        public string GetRandomEncounter(BiomeTypeEnum BiomeTypes = BiomeTypeEnum.Dungeon)
        {



            return BiomeTypes.ToString();
        }
    }
}
