﻿using Microsoft.EntityFrameworkCore;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Infastructure.Persistence
{
    internal class WorldTravelDbContext(DbContextOptions<WorldTravelDbContext> options) : DbContext(options)
    {
        internal DbSet<Continent> Continents { get; set; }
        internal DbSet<Country> Countries { get; set; }
        internal DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // do not auto generate and use ISO codes instead
            modelBuilder.Entity<Country>().Property(c => c.Id).ValueGeneratedNever();
            modelBuilder.Entity<Continent>().Property(c => c.Id).ValueGeneratedNever();
        }
    }
}
