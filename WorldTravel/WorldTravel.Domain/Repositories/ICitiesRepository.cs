using WorldTravel.Domain.Entities;

namespace WorldTravel.Domain.Repositories;

public interface ICitiesRepository
{
    Task<IEnumerable<City>> GetAllAsync();
    Task<City?> GetByIdAsync(int id);
    Task<int> CreateAsync(City city);
    Task DeleteAsync(City city);
    Task SaveChangesAsync();
}
