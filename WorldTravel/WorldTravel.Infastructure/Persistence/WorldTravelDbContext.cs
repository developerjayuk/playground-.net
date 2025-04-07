using Microsoft.EntityFrameworkCore;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Infastructure.Persistence
{
    internal class WorldTravelDbContext(DbContextOptions<WorldTravelDbContext> options) : DbContext(options)
    {
        internal DbSet<Country> Countries { get; set; }
        internal DbSet<Continent> Continents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().Property(c => c.Id).ValueGeneratedNever();
            modelBuilder.Entity<Continent>().Property(c => c.Id).ValueGeneratedNever();
        }
    }
}
