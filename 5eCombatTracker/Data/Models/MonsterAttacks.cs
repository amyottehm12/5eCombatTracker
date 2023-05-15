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

        public virtual Monster Monster { get; set; }


        //a FK int to monster personality types, allowing for new attacks?
        //Is an arcanist a personality? for additional spells?
        //If its a brawler/skulker, how does this present in attacks? or is it ONLY for other behaviours?

        //a bool for enchanted values?
        //can i make this more interesting then just converting damage into some elemental type?

        public static MonsterAttack FromCsv(string csvLine)
        {
            string[] data = csvLine.Split(',');
            MonsterAttack attack = new MonsterAttack();
            attack.MonsterId = int.TryParse(data[0], out int result) ? result : 0;
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
