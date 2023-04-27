using FluentMigrator.Runner;
using System.Runtime.CompilerServices;

namespace _5eCombatTracker.Migrations
{
    public static class MigrationsExtensions
    {
        public static IApplicationBuilder Migrate(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
            migrator?.ListMigrations();
            migrator?.MigrateUp();
            return app;
        }
    }
}
