using WorldTravel.Domain.Entities;

namespace WorldTravel.Domain.Repositories;

public interface IContinentsRepository
{
    Task<IEnumerable<Continent>> GetAllAsync();
    Task<Continent?> GetByIdAsync(string id);
}
