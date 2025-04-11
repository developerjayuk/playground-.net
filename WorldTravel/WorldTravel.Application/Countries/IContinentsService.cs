using WorldTravel.Application.Countries.Dtos;
namespace WorldTravel.Application.Countries
{
    public interface IContinentsService
    {
        Task<IEnumerable<ContinentDto>> GetAllContinents();
        Task<ContinentDto?> GetContinentById(string id);
    }
}