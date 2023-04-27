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
            if (!_dataContext.Monster.Any())
            {
                var MonsterSeeder = new MonsterSeeder(_dataContext, _environment);
                MonsterSeeder.Seed();
            }
        }
    }
}
