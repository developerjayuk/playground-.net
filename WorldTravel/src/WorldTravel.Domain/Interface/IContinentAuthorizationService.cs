using WorldTravel.Domain.Constants;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Domain.Interface
{
    public interface IContinentAuthorizationService
    {
        bool Authorize(Continent continent, ResourceOperation operation);
    }
}