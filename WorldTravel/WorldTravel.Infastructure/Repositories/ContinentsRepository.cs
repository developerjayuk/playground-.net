using Microsoft.EntityFrameworkCore;
using WorldTravel.Domain.Constants;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Repositories;
using WorldTravel.Infastructure.Persistence;

namespace WorldTravel.Infastructure.Repositories;

internal class ContinentsRepository(WorldTravelDbContext dbContext) : IContinentsRepository
{
    public async Task<(IEnumerable<Continent>, int)> GetAllAsync()
    {
        var continents = await dbContext.Continents
            .Include(c => c.Countries)
            .ToListAsync();

        return (continents, continents.Count);
    }

    public async Task<Continent?> GetByIdAsync(string id)
    {
        var continent = await dbContext.Continents
            .Include(c => c.Countries)
            .FirstOrDefaultAsync(c => c.Id == id);
        return continent;
    }

    public async Task<string> CreateAsync(Continent continent)
    {
        await dbContext.Continents.AddAsync(continent);
        await dbContext.SaveChangesAsync();
        return continent.Id;
    }

    public async Task DeleteAsync(Continent continent)
    {
        dbContext.Continents.Remove(continent);
        await dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}
