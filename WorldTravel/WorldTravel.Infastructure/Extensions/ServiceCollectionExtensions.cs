using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorldTravel.Infastructure.Persistence;
using WorldTravel.Infastructure.Seeders;
using WorldTravel.Infastructure.Repositories;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Infastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("WorldTravelDb");
        services.AddDbContext<WorldTravelDbContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

        services.AddScoped<IWorldTravelSeeder, WorldTravelSeeder>();
        services.AddScoped<IContinentsRepository, ContinentsRepository>();
        services.AddScoped<ICountriesRepository, CountriesRepository>();
        services.AddScoped<ICitiesRepository, CitiesRepository>();
    }
}

