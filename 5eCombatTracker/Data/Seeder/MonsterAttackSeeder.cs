using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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
                List<MonsterAttacks> attacks = File.ReadAllLines(filePath).Select(x => FromCsv(x)).ToList();

                foreach (MonsterAttack attack in attacks)
                {
                    _dataContext.MonsterAttacks
                       .Add(attack);
                }
                _dataContext.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }

        private MonsterAttacks FromCsv(string csvLine)
        {
            string[] data = csvLine.Split(',');
            Monster monster = _dataContext.Monster.FirstOrDefault(m => m.Name == data[0]);
            MonsterAttacks attack = new MonsterAttacks();
            attack.MonsterId = data[0];
            attack.Monster = monster;
            attack.WeaponName = data[1];
            attack.HitRoll = Convert.ToInt32(data[2]);
            attack.DamageDie = Convert.ToInt32(data[3]);
            attack.DamageBonus = Convert.ToInt32(data[4]);
            attack.ExtraEffect = data[5];
            attack.DescriptionSet = new List<string> { data[6] };

            return attack;
        }
    }
}
