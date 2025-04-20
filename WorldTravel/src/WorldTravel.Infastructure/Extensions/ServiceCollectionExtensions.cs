using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorldTravel.Infastructure.Persistence;
using WorldTravel.Infastructure.Seeders;
using WorldTravel.Infastructure.Repositories;
using WorldTravel.Domain.Repositories;
using WorldTravel.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using WorldTravel.Infastructure.Authorization;
using WorldTravel.Infastructure.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using WorldTravel.Infastructure.Authorization.Services;
using WorldTravel.Domain.Interface;

namespace WorldTravel.Infastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("WorldTravelDb");
        services.AddDbContext<WorldTravelDbContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddClaimsPrincipalFactory<CountryUserClaimsPrincipalFactory>()
            .AddEntityFrameworkStores<WorldTravelDbContext>();

        services.AddScoped<IWorldTravelSeeder, WorldTravelSeeder>();
        services.AddScoped<IContinentsRepository, ContinentsRepository>();
        services.AddScoped<ICountriesRepository, CountriesRepository>();
        services.AddScoped<ICitiesRepository, CitiesRepository>();

        // just an example of how to use
        services.AddAuthorizationBuilder()
            .AddPolicy(PolicyNames.Atleast18, builder => builder.AddRequirements(new MinimumAgeRequirement(18)));
        services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
        services.AddScoped<ICountryAuthorizationService, CountryAuthorizationService>();
        services.AddScoped<IContinentAuthorizationService, ContinentAuthorizationService>();
    }
}

