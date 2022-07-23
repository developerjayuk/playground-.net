using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
    opts.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Developer Jay's API",
        Description = "Here is the description for my API.",
        TermsOfService = new Uri("https://mywebsite.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Developer Jay",
            Url = new Uri("https://www.developerjay.uk")
        },
        License = new OpenApiLicense
        {
            Name = "My license is here",
            Url = new Uri("https://www.deverloperjay.uk/license")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    opts.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(opts =>
    {
        // if you want to set it to version 2 
        //opts.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(opts =>
    {
        opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        opts.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
