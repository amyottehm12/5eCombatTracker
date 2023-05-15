using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;
using Microsoft.Extensions.Options;

namespace _5eCombatTracker.Data.Seeder
{
    public class EncounterSeeder
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _environment;

        public EncounterSeeder(DataContext dataContext, IWebHostEnvironment environment)
        {
            _dataContext = dataContext;
            _environment = environment;
        }

        public void Seed()
        {
            try
            {
                string root = _environment.ContentRootPath;
                string filePath = Path.GetFullPath(Path.Combine(root, "Data/CSVSeedData", "encounter.csv"));
                List<Encounter> encounters = File.ReadAllLines(filePath).Select(x => FromCsv(x)).ToList();

                foreach (Encounter encounter in encounters)
                {
                    _dataContext.Encounters
                       .Add(encounter);
                }
                _dataContext.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }

        public Encounter FromCsv(string csvLine)
        {
            string[] data = csvLine.Split(',');
            Encounter encounter = new Encounter();
            encounter.BiomeType = _dataContext.BiomeTypes.FirstOrDefault(bt => bt.Name == data[0]);
            encounter.BiomeTypeId = encounter.BiomeType.Id;
            encounter.Name = data[1];
            encounter.MonsterGroupId = Convert.ToInt32(data[2]);
            

            return encounter;
        }
    }
}
