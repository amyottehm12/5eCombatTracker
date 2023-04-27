using Microsoft.AspNetCore.Mvc;
using _5eCombatTracker.API.Interfaces;
using _5eCombatTracker.Data.DTO;

namespace _5eCombatTracker.API.Controllers
{
    [ApiController]
    public class MonsterController : ControllerBase
    {

        private readonly IMonsterService _monsterService;
        public MonsterController(IMonsterService monsterService) 
        {
            _monsterService = monsterService;
        }

        [HttpGet]
        [Route("api/[controller]/[action]/{name}")]
        public async Task<ActionResult<MonsterDTO>> GetMonstersByNameAsync(string name)
        {
            try
            {
                var responseData = await _monsterService.GetMonsters(name);
                if (responseData == null) { return StatusCode(StatusCodes.Status404NotFound); }
                return Ok(responseData);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<ActionResult<List<string>>> GetAllMonsters()
        {
            try
            {
                var responseData = await _monsterService.GetAllMonsters();
                return Ok(responseData);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
