using _5eCombatTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _5eCombatTracker.Data.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("5eCombatTracker"));
        }

        public DbSet<Monster> Monsters { get; set; }
        public DbSet<MonsterGroup> MonsterGroups { get; set; }

        public DbSet<BiomeType> BiomeTypes { get; set; }
        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<MonsterAttack> MonsterAttacks { get; set; }

    }
}
