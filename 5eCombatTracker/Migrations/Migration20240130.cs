using FluentMigrator;

namespace _5eCombatTracker.Migrations
{
    [Migration(20240130)]
    public class Migration20240130 : Migration
    {
        public override void Up()
        {
            Alter.Table("MonsterAttack")
                .AddColumn("NumberOfDice").AsInt16().WithDefaultValue(1)
                .AddColumn("NumberOfAttacks").AsInt16().WithDefaultValue(1);
        }

        public override void Down()
        {
        }
    }
}
