using WorldTravel.Domain.Entities;

namespace WorldTravel.Domain.Repositories;

public interface ICountriesRepository
{
    Task<IEnumerable<Country>> GetAllAsync();
    Task<(IEnumerable<Country>, int)> GetAllMatchingSearchAsync(string? searchPhrase, int? page, int? size);
    Task<Country?> GetByIdAsync(string id);
    Task<string> CreateAsync(Country country);
    Task DeleteAsync(Country country);
    Task SaveChangesAsync();
}
