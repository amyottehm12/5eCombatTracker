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
                List<Monster> monsters = File.ReadAllLines(filePath).Skip(1).Select(x => FromCsv(x)).ToList();

                foreach (Monster monster in monsters)
                {
                    _dataContext.Monsters
                       .Add(monster);
                }
                    _dataContext.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }

        private Monster FromCsv(string csvLine)
        {
            string[] data = csvLine.Split(',');
            Monster monster = new Monster();
            monster.Name = data[0];
            monster.URL = data[1];
            monster.CR = data[2];
            monster.Type = data[3];
            monster.Size = data[4];
            monster.AC = Convert.ToInt32(data[5]);
            monster.HP = Convert.ToInt32(data[6]);
            monster.Speed = data[7];
            monster.Alignment = data[8];
            monster.Legendary = data[9];
            monster.Source = data[10];
            monster._Str = (data[11] == null) ? Convert.ToDecimal(data[11]) : 0;
            monster._Dex = (data[12] == null) ? Convert.ToDecimal(data[12]) : 0;
            monster._Con = (data[13] == null) ? Convert.ToDecimal(data[13]) : 0;
            monster._Int = (data[14] == null) ? Convert.ToDecimal(data[14]) : 0;
            monster._Wis = (data[15] == null) ? Convert.ToDecimal(data[15]) : 0;
            monster._Cha = (data[16] == null) ? Convert.ToDecimal(data[16]) : 0;

            return monster;
        }

    }
}
