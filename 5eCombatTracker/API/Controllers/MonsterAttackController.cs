using Microsoft.AspNetCore.Mvc;
using _5eCombatTracker.API.Interfaces;
using _5eCombatTracker.Data.DTO;

namespace _5eCombatTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterAttackController : ControllerBase
    {

        private readonly IMonsterAttackService _monsterAttackService;
        public MonsterAttackController(IMonsterAttackService monsterAttackService) 
        {
            _monsterAttackService = monsterAttackService;
        }

        /// <summary>
        /// Get random monster attack
        /// </summary>
        /// <response code="200">Random monster attack retreived successfully</response>
        /// <response code="404">No monster attack for this id found</response>
        /// <response code="500">Something went wrong retrieving monster attack</response>
        [HttpGet]
        [Route("random")]
        public async Task<IActionResult> GetRandomMonsterAttack(int id)
        {
            try
            {
                var responseData = await _monsterAttackService.GetRandomMonsterAttack(id);
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
