using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Infastructure.Persistence
{
    internal class WorldTravelDbContext(DbContextOptions<WorldTravelDbContext> options) : IdentityDbContext<User>(options)
    {
        internal DbSet<Continent> Continents { get; set; }
        internal DbSet<Country> Countries { get; set; }
        internal DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // do not auto generate and use ISO codes instead
            modelBuilder.Entity<Continent>().Property(c => c.Id).ValueGeneratedNever();
            modelBuilder.Entity<Country>().Property(c => c.Id).ValueGeneratedNever();

            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedCountries)
                .WithOne(c => c.CreatedBy)
                .HasForeignKey(c => c.CreatedById);

            modelBuilder.Entity<Country>()
                .HasOne<Continent>()
                .WithMany(c => c.Countries)
                .HasForeignKey(c => c.ContinentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<City>()
                .HasOne<Country>()
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
