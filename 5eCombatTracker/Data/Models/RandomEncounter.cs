using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5eCombatTracker.Data.Models
{
    public class RandomEncounter
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("BiomeType")]
        public BiomeType Biome { get; set; }
        public string Name { get; set; }
        public List<string> MonsterGroup { get; set; }
    }
}
