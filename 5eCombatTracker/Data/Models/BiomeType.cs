using System.ComponentModel.DataAnnotations;

namespace _5eCombatTracker.Data.Models
{
    public class BiomeType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
