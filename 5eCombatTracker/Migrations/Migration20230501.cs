using FluentMigrator;
using System.Collections.Generic;

namespace _5eCombatTracker.Migrations
{
    [Migration(20230501)]
    public class Migration20230501 : Migration
    {
        public override void Up()
        {
            var arrayInsert =
                "INSERT INTO public.\"RandomEncounter\"(\r\n\t\"Id\", \"BiomeType\", \"Name\", \"MonsterGroup\")\r\n\tVALUES \r\n\t(1, 3, 'The Zombies', '{ \"Zombie\", \"Zombie\", \"Zombie\" }'),\r\n\t(2, 3, 'The Skeletons', '{ \"Skeleton\", \"Skeleton\", \"Skeleton\" }'),\r\n\t(3, 3, 'Undead Mix', '{ \"Skeleton\", \"Zombie\", \"Zombie\" }');";

            Execute.Sql(arrayInsert);

            var uuidScript = "CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";";

            Execute.Sql(uuidScript);
        }

        public override void Down()
        {

        }
    }
}
