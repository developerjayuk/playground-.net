using WorldTravel.Application.WorldTravel.Dtos;
namespace WorldTravel.Application.WorldTravel
{
    public interface IContinentsService
    {
        Task<IEnumerable<ContinentDto>> GetAllContinents();
        Task<ContinentDto?> GetContinentById(string id);
    }
}