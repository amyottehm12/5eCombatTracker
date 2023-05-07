using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;

namespace _5eCombatTracker.Data.Seeder
{
    public class MonsterAttackSeeder
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _environment;

        public MonsterAttackSeeder(DataContext dataContext, IWebHostEnvironment environment)
        {
            _dataContext = dataContext;
            _environment = environment;
        }

        public void Seed()
        {
            try
            {
                string root = _environment.ContentRootPath;
                string filePath = Path.GetFullPath(Path.Combine(root, "Data/CSVSeedData", "monster_attacks.csv"));
                List<MonsterAttacks> attacks = File.ReadAllLines(filePath).Select(x => MonsterAttacks.FromCsv(x)).ToList();

                foreach (MonsterAttacks attack in attacks)
                {
                    _dataContext.MonsterAttacks
                       .Add(attack);
                }

                _dataContext.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
