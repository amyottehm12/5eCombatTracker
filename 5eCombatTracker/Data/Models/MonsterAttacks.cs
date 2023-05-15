using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5eCombatTracker.Data.Models
{
    public class MonsterAttacks
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Monster")]
        public string MonsterId { get; set; }
        public Monster Monster { get; set; }
        public string WeaponName { get; set; }
        public int? HitRoll { get; set; }
        public int DamageDie { get; set; }
        public int DamageBonus { get; set; }
        public string ExtraEffect { get; set; }
        public List<string> DescriptionSet { get; set; }

        //a FK int to monster personality types, allowing for new attacks?
        //Is an arcanist a personality? for additional spells?
        //If its a brawler/skulker, how does this present in attacks? or is it ONLY for other behaviours?

        //a bool for enchanted values?
        //can i make this more interesting then just converting damage into some elemental type?
    }
}
