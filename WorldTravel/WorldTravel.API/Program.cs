using WorldTravel.Infastructure.Extensions;
using WorldTravel.Infastructure.Seeders;
using WorldTravel.Application.Extensions;
using Serilog;
using WorldTravel.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<RequestTimeLoggerMiddleware>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// seed initial data if needed
var seeder = app.Services.CreateScope().ServiceProvider.GetRequiredService<IWorldTravelSeeder>();
await seeder.Seed();

// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeLoggerMiddleware>();
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
