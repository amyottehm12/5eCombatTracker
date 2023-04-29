using _5eCombatTracker.Data.Models;
using FluentMigrator;

namespace _5eCombatTracker.Migrations
{
    [Migration(20232704)]
    public class Migration20232704 : Migration
    {
        public override void Up()
        {
            Create.Table("Monster")
                .WithColumn("Name").AsString().NotNullable().PrimaryKey()
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

            Create.Table("BiomeType")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString()
                .WithColumn("Description").AsString();

            Insert.IntoTable("BiomeType")
                .Row(new { Name = "Forest", Description = "Forest" })
                .Row(new { Name = "Mountains", Description = "Mountains" })
                .Row(new { Name = "Dungeon", Description = "Dungeon" });

            Create.Table("RandomEncounter")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("BiomeType").AsInt32().ForeignKey()
                .WithColumn("Name").AsString()
                .WithColumn("MonsterGroup").AsString();

            Insert.IntoTable("RandomEncounter")
                .Row(new { BiomeType = 3, Name = "The Zombies", MonsterGroup = "{'Monsters':['Zombie', 'Zombie', 'Zombie']}" })
                .Row(new { BiomeType = 3, Name = "The Skeletons", MonsterGroup = "{'Monsters':['Skeleton', 'Skeleton', 'Skeleton']}" })
                .Row(new { BiomeType = 3, Name = "Undead Mix", MonsterGroup = "{'Monsters':['Skeleton', 'Zombie', 'Zombie']}" })
                .Row(new { BiomeType = 3, Name = "Treasure", MonsterGroup = "{'Monsters':['Treasure Chest']}" });
        }

        public override void Down()
        {

        }
    }
}
