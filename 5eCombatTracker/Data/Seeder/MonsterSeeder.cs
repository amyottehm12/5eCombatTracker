using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;

namespace _5eCombatTracker.Data.Seeder
{
    public class MonsterSeeder
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _environment;

        public MonsterSeeder(DataContext dataContext, IWebHostEnvironment environment)
        {
            _dataContext = dataContext;
            _environment = environment;
        }

        public void Seed()
        {
            try
            {
                string root = _environment.ContentRootPath;
                string filePath = Path.GetFullPath(Path.Combine(root, "Data/CSVSeedData", "dnd_monsters.csv"));
                List<Monster> monsters = File.ReadAllLines(filePath).Skip(1).Select(x => Monster.FromCsv(x)).ToList();

                foreach (Monster monster in monsters)
                {
                    _dataContext.Monster
                       .Add(monster);
                }

                _dataContext.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }

    }
}
