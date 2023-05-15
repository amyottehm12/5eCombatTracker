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

    }
}
