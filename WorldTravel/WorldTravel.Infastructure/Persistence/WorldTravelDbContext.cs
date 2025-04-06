using Microsoft.EntityFrameworkCore;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Infastructure.Persistence
{
    internal class WorldTravelDbContext : DbContext
    {
        internal DbSet<Country> Countries { get; set; }
        internal DbSet<Continent> Continents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-4KPO210\\SQLEXPRESS;Database=WorldTravel;Trusted_Connection=True;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                
        }
    }
}
