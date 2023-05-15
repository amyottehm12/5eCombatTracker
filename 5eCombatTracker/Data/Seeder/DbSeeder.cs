using _5eCombatTracker.Data.Helpers;

namespace _5eCombatTracker.Data.Seeder
{
    public class DbSeeder : IDbSeeder
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _environment;

        public DbSeeder(DataContext dataContext, IWebHostEnvironment environment)
        { 
            _dataContext = dataContext;
            _environment = environment;
        }

        public void Seed()
        {
            _dataContext.Database.EnsureCreated();
            if (!_dataContext.Monsters.Any())
            {
                var MonsterSeeder = new MonsterSeeder(_dataContext, _environment);
                MonsterSeeder.Seed();
            }

            if (!_dataContext.MonsterAttacks.Any())
            {
                var MonsterAttackSeeder = new MonsterAttackSeeder(_dataContext, _environment);
                MonsterAttackSeeder.Seed();
            }

            if (!_dataContext.MonsterGroups.Any())
            {
                var MonsterGroupSeeder = new MonsterGroupSeeder(_dataContext, _environment);
                MonsterGroupSeeder.Seed();
            }

            if (!_dataContext.Encounters.Any())
            {
                var EncounterSeeder = new EncounterSeeder(_dataContext, _environment);
                EncounterSeeder.Seed();
            }


        }
    }
}
