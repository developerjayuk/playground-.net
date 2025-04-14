using WorldTravel.Domain.Entities;

namespace WorldTravel.Domain.Repositories;

public interface IContinentsRepository
{
    Task<(IEnumerable<Continent>, int)> GetAllAsync();
    Task<Continent?> GetByIdAsync(string id);
    Task<string> CreateAsync(Continent continent);
    Task DeleteAsync(Continent continent);
    Task SaveChangesAsync();
}
