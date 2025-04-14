using WorldTravel.Domain.Constants;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Domain.Repositories;

public interface ICountriesRepository
{
    Task<IEnumerable<Country>> GetAllAsync();
    Task<(IEnumerable<Country>, int)> GetAllMatchingSearchAsync(string? searchPhrase, int? page, int? size, string? sortBy, Sort? direction);
    Task<Country?> GetByIdAsync(string id);
    Task<string> CreateAsync(Country country);
    Task DeleteAsync(Country country);
    Task SaveChangesAsync();
}
