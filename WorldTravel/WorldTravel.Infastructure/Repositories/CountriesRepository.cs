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
            .Include(c => c.Cities)
            .ToListAsync();
        return countries;
    }

    public async Task<Country?> GetByIdAsync(string id)
    {
        var country = await dbContext.Countries
            .Include(c => c.Cities)
            .FirstOrDefaultAsync(c => c.Id == id);
        return country;
    }

    public async Task<string> CreateAsync(Country country)
    {
        await dbContext.Countries.AddAsync(country);
        await dbContext.SaveChangesAsync();
        return country.Id;
    }

    public async Task DeleteAsync(Country country)
    {
        dbContext.Countries.Remove(country);
        await dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}
