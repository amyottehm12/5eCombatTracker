using FluentMigrator;

namespace _5eCombatTracker.Migrations
{
    [Migration(20240131)]
    public class Migration20240131 : Migration
    {
        public override void Up()
        {
            Create.Table("DamageType")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable();

            Insert.IntoTable("DamageType")
                .Row(new { Name = "Radiant" })
                .Row(new { Name = "Necrotic" })
                .Row(new { Name = "Psychic" })
                .Row(new { Name = "Elemental" })
                .Row(new { Name = "Fire" })
                .Row(new { Name = "Cold" })
                .Row(new { Name = "Lightning" })
                .Row(new { Name = "Thunder" })
                .Row(new { Name = "Acid" })
                .Row(new { Name = "Poison" })
                .Row(new { Name = "Force" })
                .Row(new { Name = "Physical" })
                .Row(new { Name = "Piercing" })
                .Row(new { Name = "Bludgeoning" })
                .Row(new { Name = "Slashing" });

            Alter.Table("MonsterAttack")
                .AddColumn("DamageTypeId").AsInt32().ForeignKey().SetExistingRowsTo(1);

            Create.ForeignKey()
                .FromTable("MonsterAttack").ForeignColumn("DamageTypeId")
                .ToTable("DamageType").PrimaryColumn("Id");
        }

        public override void Down()
        {
        }
    }
}
