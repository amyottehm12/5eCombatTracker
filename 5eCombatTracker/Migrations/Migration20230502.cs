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
               .WithColumn("MonsterName").AsString().NotNullable().ForeignKey()
               .WithColumn("WeaponName").AsString()
               .WithColumn("DamageDie").AsInt32()
               .WithColumn("DamageBonus").AsInt32()
               .WithColumn("ExtraEffect").AsString()
               .WithColumn("DescriptionSet").AsCustom("TEXT[]");

            Create.ForeignKey()
                .FromTable("MonsterAttacks").ForeignColumn("MonsterName")
                .ToTable("Monster").PrimaryColumn("Name");

            Insert.IntoTable("MonsterAttacks")
                .Row(new { MonsterName = "zombie", WeaponName = "Slam", DamageDie = 6, DamageBonus = 1, ExtraEffect = "none", DescriptionSet = "{}" })
                .Row(new { MonsterName = "zombie", WeaponName = "Bite", DamageDie = 4, DamageBonus = 1, ExtraEffect = "Saving throw vs con for disease", DescriptionSet = "{}" })
                .Row(new { MonsterName = "zombie", WeaponName = "Acid Spit", DamageDie = 4, DamageBonus = 2, ExtraEffect = "Saving throw vs con for 2 acid damage", DescriptionSet = "{}" })
                .Row(new { MonsterName = "zombie", WeaponName = "Graple", DamageDie = 0, DamageBonus = 0, ExtraEffect = "Saving throw vs str for prone", DescriptionSet = "{}" })
                .Row(new { MonsterName = "skeleton", WeaponName = "Shortsword", DamageDie = 6, DamageBonus = 2, ExtraEffect = "none", DescriptionSet = "{}" })
                .Row(new { MonsterName = "skeleton", WeaponName = "Skeletal claw", DamageDie = 6, DamageBonus = 2, ExtraEffect = "none", DescriptionSet = "{}" })
                .Row(new { MonsterName = "skeleton", WeaponName = "shortbow", DamageDie = 4, DamageBonus = 2, ExtraEffect = "none", DescriptionSet = "{}" });
        }

        public override void Down()
        {

        }
    }
}
