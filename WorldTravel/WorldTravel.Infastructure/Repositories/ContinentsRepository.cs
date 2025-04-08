using Microsoft.EntityFrameworkCore;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Repositories;
using WorldTravel.Infastructure.Persistence;

namespace WorldTravel.Infastructure.Repositories;

internal class ContinentsRepository(WorldTravelDbContext dbContext) : IContinentsRepository
{
    public async Task<IEnumerable<Continent>> GetAllAsync()
    {
        var continents = await dbContext.Continents
            .Include(c => c.Countries)
            .ToListAsync();
        return continents;
    }

    public async Task<Continent?> GetByIdAsync(string id)
    {
        var continent = await dbContext.Continents
            .Include(c => c.Countries)
            .FirstOrDefaultAsync(c => c.Id == id);
        return continent;
    }
}
