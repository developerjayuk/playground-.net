using Microsoft.EntityFrameworkCore;
using WorldTravel.Domain.Entities;
using WorldTravel.Infastructure.Persistence;

namespace WorldTravel.Infastructure.Seeders;

internal class WorldTravelSeeder(WorldTravelDbContext dbContext) : IWorldTravelSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (await dbContext.Countries.AnyAsync())
            {
                return;
            }

            var countries = GetCountries();
            var continents = GetContinents();

            await dbContext.Continents.AddRangeAsync(continents);
            await dbContext.Countries.AddRangeAsync(countries);
            await dbContext.SaveChangesAsync();
        }
    }
    private IEnumerable<Continent> GetContinents()
    {
        // https://datahub.io/core/continent-codes
        return
        [
            new Continent
            {
                Id = "AF",
                Name = "Africa",
                Description = "A vast and diverse continent known for its rich cultures, stunning wildlife, and historical significance as the cradle of humanity."
            },
            new Continent
            {
                Id = "AN",
                Name = "Antartica",
                Description = "A remote, icy wilderness dedicated to science and exploration, home to extreme conditions and stunning polar beauty.",
            },
            new Continent
            {
                Id = "AS",
                Name = "Asia",
                Description = "The largest and most populous continent, home to ancient civilizations, booming economies, and breathtaking natural and urban landscapes.",
            },
            new Continent
            {
                Id = "EU",
                Name = "Europe",
                Description = "A continent steeped in history and art, blending medieval charm with modern innovation across a patchwork of nations.",
            },
            new Continent
            {
                Id = "NA",
                Name = "North America",
                Description = "A dynamic continent featuring cultural diversity, expansive landscapes, and global economic and technological influence.",
            },
            new Continent
            {
                Id = "OC",
                Name = "Oceania",
                Description = "A unique region with stunning biodiversity, indigenous heritage, and laid-back coastal lifestyles spread across islands and the Australian mainland.",
            },
            new Continent
            {
                Id = "SA",
                Name = "South America",
                Description = " A vibrant continent known for its natural wonders, passionate cultures, and a deep legacy of indigenous and colonial history.",
            },
        ];
    }
    private IEnumerable<Country> GetCountries()
    {
        // https://en.wikipedia.org/wiki/List_of_ISO_3166_country_codes
        return
        [
            new Country
            {
                Id = "US",
                Name = "United States",
                Description = "A country in North America.",
                ContinentId = "NA"
            },
            new Country
            {
                Id = "CA",
                Name = "Canada",
                Description = "A country in North America.",
                ContinentId = "NA"
            },
            new Country
            {
                Id = "FR",
                Name = "France",
                Description = "A country in Europe.",
                ContinentId = "EU"
            }
        ];
    }
}
