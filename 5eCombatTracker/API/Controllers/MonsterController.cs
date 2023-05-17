using Microsoft.AspNetCore.Mvc;
using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.API.Interfaces.Services;

namespace _5eCombatTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {

        private readonly IMonsterService _monsterService;
        public MonsterController(IMonsterService monsterService) 
        {
            _monsterService = monsterService;
        }

        /// <summary>
        /// Get monster by ID
        /// </summary>
        /// <response code="200">Monster retreived successfully</response>
        /// <response code="404">No monster found</response>
        /// <response code="500">Something went wrong retrieving monster</response>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMonsterByIdAsync(int id)
        {
            try
            {
                var responseData = await _monsterService.GetMonsterById(id);
                if (responseData == null) { return StatusCode(StatusCodes.Status404NotFound); }
                return Ok(responseData);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Get monster by name
        /// </summary>
        /// <response code="200">Monster retreived successfully</response>
        /// <response code="404">No monster found</response>
        /// <response code="500">Something went wrong retrieving monster</response>
        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> GetMonsterByNameAsync(string name)
        {
            try
            {
                var responseData = await _monsterService.GetMonsterByName(name);
                if (responseData == null) { return StatusCode(StatusCodes.Status404NotFound); }
                return Ok(responseData);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Get all monsters
        /// </summary>
        /// <response code="200">Monsters retreived successfully</response>
        /// <response code="404">No monsters found</response>
        /// <response code="500">Something went wrong retrieving monsters</response>
        [HttpGet]
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
    }
}
