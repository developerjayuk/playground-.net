using Microsoft.Extensions.DependencyInjection;
using WorldTravel.Application.WorldTravel;

namespace WorldTravel.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICountriesService, CountriesService>();
        services.AddScoped<IContinentsService, ContinentsService>();

        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
    }
}
