using FluentMigrator;

namespace _5eCombatTracker.Migrations
{
    [Migration(20230502)]
    public class Migration20230502 : Migration
    {
        public override void Up()
        {
            Create.Table("MonsterAttacks")
               .WithColumn("Id").AsString().Identity().NotNullable().PrimaryKey()
               .WithColumn("MonsterId").AsString().NotNullable().ForeignKey()
               .WithColumn("WeaponName").AsString()
               .WithColumn("HitRoll").AsInt32().Nullable()
               .WithColumn("DamageDie").AsInt32()
               .WithColumn("DamageBonus").AsInt32()
               .WithColumn("ExtraEffect").AsString()
               .WithColumn("DescriptionSet").AsCustom("TEXT[]");

            Create.ForeignKey()
                .FromTable("MonsterAttacks").ForeignColumn("MonsterId")
                .ToTable("Monster").PrimaryColumn("Name");
        }

        public override void Down()
        {

        }
    }
}
