using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

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
        public string GetRandomEncounter(BiomeTypes BiomeTypes = BiomeTypes.Dungeon)
        {



            return BiomeTypes.ToString();
        }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BiomeTypes
    {
        Forest = 1,
        Dungeon = 2
    }
}
