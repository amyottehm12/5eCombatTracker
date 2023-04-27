using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace _5eCombatTracker.Data.Models
{
    public class Monster
    {
        [Key]
        public string? Name { get; set; }
        public string? URL { get; set; }
        public string? CR { get; set; }
        public string? Type { get; set; }
        public string? Size { get; set; }
        public int? AC { get; set; }
        public int? HP { get; set; }
        public string? Speed { get; set; }
        public string? Alignment { get; set; }
        public string? Legendary { get; set; }
        public string? Source { get; set; }
        public decimal? _Str { get; set; }
        public decimal? _Dex { get; set; }
        public decimal? _Con { get; set; }
        public decimal? _Int { get; set; }
        public decimal? _Wis { get; set; }
        public decimal? _Cha { get; set; }

        public static Monster FromCsv(string csvLine)
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
