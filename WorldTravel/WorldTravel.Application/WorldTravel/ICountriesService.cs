using WorldTravel.Application.WorldTravel.Dtos;
namespace WorldTravel.Application.WorldTravel
{
    public interface ICountriesService
    {
        Task<IEnumerable<CountryDto>> GetAllCountries();
        Task<CountryDto?> GetCountryById(string id);
    }
}