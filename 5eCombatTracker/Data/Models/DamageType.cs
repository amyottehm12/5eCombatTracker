using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5eCombatTracker.Data.Models
{
    [Table("DamageType", Schema = "public")]
    public class DamageType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
