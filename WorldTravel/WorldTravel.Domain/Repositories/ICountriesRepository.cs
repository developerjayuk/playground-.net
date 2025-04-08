using WorldTravel.Domain.Entities;

namespace WorldTravel.Domain.Repositories;

public interface ICountriesRepository
{
    Task<IEnumerable<Country>> GetAllAsync();
    Task<Country?> GetByIdAsync(string id);
}
