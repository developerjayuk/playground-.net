using WorldTravel.Infastructure.Extensions;
using WorldTravel.Infastructure.Seeders;
using WorldTravel.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// seed initial data if needed
var seeder = app.Services.CreateScope().ServiceProvider.GetRequiredService<IWorldTravelSeeder>();
await seeder.Seed();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
