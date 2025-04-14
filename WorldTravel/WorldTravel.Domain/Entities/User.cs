using Microsoft.AspNetCore.Identity;

namespace WorldTravel.Domain.Entities;

public class User : IdentityUser
{
    public DateOnly? DateOfBirth { get; set; }

    public List<Continent> CreatedContinents { get; set; } = [];
    public List<Country> CreatedCountries { get; set; } = [];
    public List<City> CreatedCities { get; set; } = [];
}
