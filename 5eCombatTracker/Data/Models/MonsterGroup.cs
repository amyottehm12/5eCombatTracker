using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace _5eCombatTracker.Data.Models
{
    [Table("MonsterGroup", Schema = "public")]
    [PrimaryKey(nameof(MonsterGroupId), nameof(MonsterId))]
    public class MonsterGroup
    {
        public int MonsterGroupId { get; set; }
        [ForeignKey("Monster")]
        public int MonsterId { get; set; }
        public int Quantity { get; set; }
        public virtual Monster Monster { get; set; }

    }
}
