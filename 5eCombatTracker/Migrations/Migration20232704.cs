using _5eCombatTracker.Data.Models;
using FluentMigrator;

namespace _5eCombatTracker.Migrations
{
    [Migration(20230427)]
    public class Migration20230427 : Migration
    {
        public override void Up()
        {
            Create.Table("Monster")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("URL").AsString()
                .WithColumn("CR").AsString()
                .WithColumn("Type").AsString()
                .WithColumn("Size").AsString()
                .WithColumn("AC").AsInt16()
                .WithColumn("HP").AsInt16()
                .WithColumn("Speed").AsString()
                .WithColumn("Alignment").AsString()
                .WithColumn("Legendary").AsString()
                .WithColumn("Source").AsString()
                .WithColumn("_Str").AsDecimal()
                .WithColumn("_Dex").AsDecimal()
                .WithColumn("_Con").AsDecimal()
                .WithColumn("_Int").AsDecimal()
                .WithColumn("_Wis").AsDecimal()
                .WithColumn("_Cha").AsDecimal();

            Insert.IntoTable("Monster")
                .Row(new { 
                    Name = "Zombie", 
                    URL = "assets/monster-images/zombie.png", 
                    CR = 1,
                    Type = "Undead",
                    Size = "M",
                    AC = 12,
                    HP = 22,
                    Speed = 30,
                    Alignment = "Chaotic Evil",
                    Legendary = "No",
                    Source = "Monster's Manual",
                    _Str = 1,
                    _Dex = 1,
                    _Con = 1,
                    _Int = 1,
                    _Wis = 1,
                    _Cha = 1
                })
                .Row(new { 
                    Name = "Skeleton", 
                    URL = "assets/monster-images/zombie.png",
                    CR = 1,
                    Type = "Undead",
                    Size = "M",
                    AC = 10,
                    HP = 20,
                    Speed = 30,
                    Alignment = "Chaotic Evil",
                    Legendary = "No",
                    Source = "Monster's Manual",
                    _Str = 1,
                    _Dex = 1,
                    _Con = 1,
                    _Int = 1,
                    _Wis = 1,
                    _Cha = 1
                });

            Create.Table("BiomeType")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString()
                .WithColumn("Description").AsString();

            Insert.IntoTable("BiomeType")
                .Row(new { Name = "Forest", Description = "Forest" })
                .Row(new { Name = "Mountains", Description = "Mountains" })
                .Row(new { Name = "Dungeon", Description = "Dungeon" });

            Create.Table("MonsterGroup")
                .WithColumn("MonsterGroupId").AsInt32().Identity().PrimaryKey()
                .WithColumn("MonsterId").AsInt32().ForeignKey().PrimaryKey()
                .WithColumn("Quantity").AsInt32().NotNullable();

            Insert.IntoTable("MonsterGroup")
                .Row(new { MonsterGroupId = 1, MonsterId = 1, Quantity = 3 })
                .Row(new { MonsterGroupId = 2, MonsterId = 2, Quantity = 3 })
                .Row(new { MonsterGroupId = 3, MonsterId = 2, Quantity = 1 })
                .Row(new { MonsterGroupId = 3, MonsterId = 1, Quantity = 2 });

            Create.Table("Encounter")
                .WithColumn("EncounterId").AsInt32().Identity().PrimaryKey()
                .WithColumn("BiomeType").AsInt32().ForeignKey()
                .WithColumn("Name").AsString()
                .WithColumn("MonsterGroupId").AsInt32().ForeignKey();

            Insert.IntoTable("Encounter")
                .Row(new { BiomeType = 3, Name = "The Zombies", MonsterGroupId = 1 })
                .Row(new { BiomeType = 3, Name = "The Skeletons", MonsterGroupId = 2 })
                .Row(new { BiomeType = 3, Name = "Undead Mix", MonsterGroupId = 3 });
        }

        public override void Down()
        {

        }
    }
}
