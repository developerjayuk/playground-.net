using Serilog;
using WorldTravel.API.Extensions;
using WorldTravel.API.Middlewares;
using WorldTravel.Application.Extensions;
using WorldTravel.Domain.Entities;
using WorldTravel.Infastructure.Extensions;
using WorldTravel.Infastructure.Seeders;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.AddPresentation();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);

    var app = builder.Build();

    // seed initial data and run migrations if needed
    var seeder = app.Services.CreateScope().ServiceProvider.GetRequiredService<IWorldTravelSeeder>();
    await seeder.Seed();

    // Configure the HTTP request pipeline.
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseMiddleware<RequestTimeLoggerMiddleware>();
    app.MapGroup("api/identity").WithTags("Identity").MapIdentityApi<User>();
    app.UseSerilogRequestLogging();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed :(");
    throw;
}
finally
{
    Log.CloseAndFlush();
}


public partial class Program { }
