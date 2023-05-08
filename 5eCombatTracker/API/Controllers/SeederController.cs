using _5eCombatTracker.Data.Seeder;
using Microsoft.AspNetCore.Mvc;

namespace _5eCombatTracker.API.Controllers
{
    [ApiController]
    public class SeederController : ControllerBase
    {

        private readonly IDbSeeder _dbSeeder;
        public SeederController(IDbSeeder DbSeeder)
        {
            _dbSeeder = DbSeeder;
        }

        [HttpPost]
        [Route("api/[controller]/monsters")]
        public void SeedData()
        {
            _dbSeeder.Seed();
        }
    }
}
