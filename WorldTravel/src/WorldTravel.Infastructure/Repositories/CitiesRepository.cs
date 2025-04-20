using Microsoft.EntityFrameworkCore;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Repositories;
using WorldTravel.Infastructure.Persistence;

namespace WorldTravel.Infastructure.Repositories;

internal class CitiesRepository(WorldTravelDbContext dbContext) : ICitiesRepository
{
    public async Task<IEnumerable<City>> GetAllAsync()
    {
        var cities = await dbContext.Cities
            .ToListAsync();
        return cities;
    }

    public async Task<City?> GetByIdAsync(int id)
    {
        var city = await dbContext.Cities
            .FirstOrDefaultAsync(c => c.Id == id);
        return city;
    }

    public async Task<int> CreateAsync(City city)
    {
        await dbContext.Cities.AddAsync(city);
        await dbContext.SaveChangesAsync();
        return city.Id;
    }

    public async Task DeleteAsync(City city)
    {
        dbContext.Cities.Remove(city);
        await dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}
