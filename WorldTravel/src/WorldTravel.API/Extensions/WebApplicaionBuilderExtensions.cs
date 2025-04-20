using Microsoft.OpenApi.Models;
using Serilog;
using WorldTravel.API.Middlewares;

namespace WorldTravel.API.Extensions;

public static class WebApplicaionBuilderExtensions
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("authBearer", new OpenApiSecurityScheme
            {
                Description = "Auth header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                Name = "Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "authBearer"}
            },
            []
        }
    });
        });
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddScoped<ErrorHandlingMiddleware>();
        builder.Services.AddScoped<RequestTimeLoggerMiddleware>();

        builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

    }
}
