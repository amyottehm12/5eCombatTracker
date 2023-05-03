using FluentMigrator;
using System.Collections.Generic;

namespace _5eCombatTracker.Migrations
{
    [Migration(20230501)]
    public class Migration20230501 : Migration
    {
        public override void Up()
        {
            //This is required for the random implementation to work
            //in EncounterService.GetRandomEncounter()
            //Guid.NewGuid()
            var uuidScript = "CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";";

            Execute.Sql(uuidScript);
        }

        public override void Down()
        {

        }
    }
}
