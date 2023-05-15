using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;

namespace _5eCombatTracker.Data.Seeder
{
    public class MonsterGroupSeeder
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _environment;

        public MonsterGroupSeeder(DataContext dataContext, IWebHostEnvironment environment)
        {
            _dataContext = dataContext;
            _environment = environment;
        }

        public void Seed()
        {
            try
            {
                string root = _environment.ContentRootPath;
                string filePath = Path.GetFullPath(Path.Combine(root, "Data/CSVSeedData", "monster_group.csv"));
                string[] lines = File.ReadAllLines(filePath);
                List<MonsterGroup> groups = new List<MonsterGroup>();
                int increment = 1;
                foreach (string line in lines)
                {
                    groups.AddRange(FromCsv(line, increment));
                    increment++;
                }

                foreach (MonsterGroup group in groups)
                {
                    _dataContext.MonsterGroups
                       .Add(group);
                }
                _dataContext.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }

        private List<MonsterGroup> FromCsv(string csvLine, int increment)
        {
            string[] data = csvLine.Split(',');

            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            foreach (string line in data)
            {
                if (!keyValuePairs.TryGetValue(line, out int value)) keyValuePairs.Add(line, 1);
                else keyValuePairs[line]++;
            }

            List<MonsterGroup> groups = new List<MonsterGroup>();
            foreach (var pair in keyValuePairs)
            {
                MonsterGroup group = new MonsterGroup();
                group.Monster = _dataContext.Monsters.FirstOrDefault(m => m.Name == pair.Key.ToLower());
                group.MonsterId = group.Monster.Id;
                group.Quantity = pair.Value;
                group.MonsterGroupId = increment;
                groups.Add(group);
            }

            return groups;
        }
    }
}
