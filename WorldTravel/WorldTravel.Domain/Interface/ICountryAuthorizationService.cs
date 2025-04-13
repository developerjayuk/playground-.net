using WorldTravel.Domain.Constants;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Domain.Interface
{
    public interface ICountryAuthorizationService
    {
        bool Authorize(Country country, ResourceOperation operation);
    }
}