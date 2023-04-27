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


        public DbSet<Monster> Monster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monster>(monster =>
            {
                monster.ToTable("monster");
            });
        }
    }
}
