using Microsoft.EntityFrameworkCore;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Repositories;
using WorldTravel.Infastructure.Persistence;

namespace WorldTravel.Infastructure.Repositories;

internal class CountriesRepository(WorldTravelDbContext dbContext) : ICountriesRepository
{
    public async Task<IEnumerable<Country>> GetAllAsync()
    {
        var countries = await dbContext.Countries
            .Include(c => c.Continent)
            .ToListAsync();
        return countries;
    }

    public async Task<Country?> GetByIdAsync(string id)
    {
        var country = await dbContext.Countries
            .Include(c => c.Continent)
            .FirstOrDefaultAsync(c => c.Id == id);
        return country;
    }
}
