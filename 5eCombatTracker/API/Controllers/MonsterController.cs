using Microsoft.AspNetCore.Mvc;
using _5eCombatTracker.API.Interfaces;
using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Seeder;

namespace _5eCombatTracker.API.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class MonsterController : ControllerBase
    {
        private readonly IMonsterService _monsterService;
        private readonly IDbSeeder _dbSeeder;
        public MonsterController(IMonsterService monsterService, IDbSeeder DbSeeder) 
        {
            _monsterService = monsterService;
            _dbSeeder = DbSeeder;
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

        //[HttpPost(Name = "SeedMonsters")]
        //public void PostMonsters()
        //{
        //    _dbSeeder.Seed();
        //}
    }
}
