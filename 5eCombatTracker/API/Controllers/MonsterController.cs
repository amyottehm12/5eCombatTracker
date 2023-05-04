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
        public async Task<IActionResult> GetMonsterByNameAsync(string name)
        {
            try
            {
                var responseData = await _monsterService.GetMonster(name);
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
        public async Task<IActionResult> GetAllMonsters()
        {
            try
            {
                var responseData = await _monsterService.GetAllMonsters();
                return Ok(responseData);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("api/[controller]/[action]/{monsterName}")]
        public async Task<IActionResult> GetRandomMonsterAttack(string monsterName)
        {
            try
            {
                var responseData = await _monsterService.GetRandomMonsterAttack(monsterName);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
