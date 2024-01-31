using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5eCombatTracker.Data.Models
{
    [Table("MonsterAttack", Schema = "public")]
    public class MonsterAttack
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Monster")]
        public int MonsterId { get; set; }
        public string WeaponName { get; set; }
        public int? HitRoll { get; set; }
        public int DamageDie { get; set; }
        public int DamageBonus { get; set; }
        public string ExtraEffect { get; set; }
        public List<string> DescriptionSet { get; set; }
        public int NumberOfDice { get; set; }
        public int NumberOfAttacks { get; set; }
        [ForeignKey("DamageType")]
        public int DamageTypeId { get; set; }


        public virtual Monster Monster { get; set; }
        public virtual DamageType DamageType { get; set; }
    }
}
