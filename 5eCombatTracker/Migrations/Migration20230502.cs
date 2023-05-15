using FluentMigrator;

namespace _5eCombatTracker.Migrations
{
    [Migration(20230502)]
    public class Migration20230502 : Migration
    {
        public override void Up()
        {
            Create.Table("MonsterAttack")
               .WithColumn("Id").AsInt32().Identity().NotNullable().PrimaryKey()
               .WithColumn("MonsterId").AsInt32().NotNullable().ForeignKey()
               .WithColumn("WeaponName").AsString()
               .WithColumn("HitRoll").AsInt32().Nullable()
               .WithColumn("DamageDie").AsInt32()
               .WithColumn("DamageBonus").AsInt32()
               .WithColumn("ExtraEffect").AsString()
               .WithColumn("DescriptionSet").AsCustom("TEXT[]");

            Create.ForeignKey()
                .FromTable("MonsterAttack").ForeignColumn("MonsterId")
                .ToTable("Monster").PrimaryColumn("Id");

            Create.ForeignKey()
                .FromTable("MonsterGroup").ForeignColumn("MonsterId")
                .ToTable("Monster").PrimaryColumn("Id");
        }

        public override void Down()
        {

        }
    }
}
