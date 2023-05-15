using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5eCombatTracker.Data.Models
{
    [Table("Encounter", Schema = "public")]
    public class Encounter
    {
        [Key]
        public int EncounterId { get; set; }
        [ForeignKey("BiomeType")]
        public int BiomeTypeId { get; set; }
        public string Name { get; set; }
        public int MonsterGroupId { get; set; }
        public virtual BiomeType BiomeType { get; set; }

    }
}
