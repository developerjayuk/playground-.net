using BasicApi.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy(PolicyConstants.MustHaveEmployeeId, policy =>
    {
        policy.RequireClaim("employeeId");
    });

    opts.AddPolicy(PolicyConstants.MustBeTheOwner, policy =>
    {
        // examples of the type of info you can require
        policy.RequireClaim("title", "CEO");
        policy.RequireUserName("homer");
    });

    opts.AddPolicy(PolicyConstants.MustBeASeniorEmployee, policy =>
    {
        // examples of the type of info you can require
        policy.RequireClaim("employeeId", "001", "002", "003");
        policy.RequireUserName("homer");
    });

    // bare minimum the user has to be authenticated to access API
    opts.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(opts =>
    {
        opts.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration
                .GetValue<string>("Authentication:Issuer"),
            ValidAudience = builder.Configuration
                .GetValue<string>("Authentication:Audience"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(builder.Configuration.GetValue<string>("Authentication:SecretKey")))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
