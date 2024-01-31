using _5eCombatTracker.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5eCombatTracker.Data.DTO
{
    public class MonsterAttackDTO
    {
        public string WeaponName { get; set; }
        public int HitRoll { get; set; }
        public int DamageDie { get; set; }
        public int DamageBonus { get; set; }
        public string ExtraEffect { get; set; }
        public int NumberOfDice { get; set; }
        public int NumberOfAttacks { get; set; }
        public string DamageTypeName { get; set; }
    }
}
