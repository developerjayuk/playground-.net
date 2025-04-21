using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WorldTravel.Domain.Constants;
using WorldTravel.Domain.Entities;
using WorldTravel.Infastructure.Persistence;

namespace WorldTravel.Infastructure.Seeders;

internal class WorldTravelSeeder(WorldTravelDbContext dbContext) : IWorldTravelSeeder
{
    // todo : add an admin user with details in the .env file
    public async Task Seed()
    {
        // check for any pending migrations
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            await dbContext.Database.MigrateAsync();
        }

        if (await dbContext.Database.CanConnectAsync())
        {
            // seed roles
            if (!await dbContext.Roles.AnyAsync())
            {
                var roles = GetRoles();
                await dbContext.Roles.AddRangeAsync(roles);
                await dbContext.SaveChangesAsync();
            }

            // seed admin user and assign admin role
            if (!await dbContext.Users.AnyAsync(u => u.UserName == "admin"))
            {
                var admin = GetAdminUser();

                await dbContext.Users.AddAsync(admin);
                await dbContext.SaveChangesAsync();

                // assign admin role
                var role = await dbContext.Roles.FirstOrDefaultAsync(r => r.Name == UserRoles.Admin);
                if (role != null)
                {
                    var userRole = new IdentityUserRole<string>
                    {
                        UserId = admin.Id,
                        RoleId = role.Id
                    };
                    await dbContext.UserRoles.AddAsync(userRole);
                    await dbContext.SaveChangesAsync();
                }
            }

            // seed continents
            if (!await dbContext.Continents.AnyAsync())
            {
                var admin = dbContext.Users.FirstOrDefault(u => u.UserName == "admin") ?? throw new InvalidOperationException("Admin user not found");

                var continents = GetContinents(admin.Id);
                await dbContext.Continents.AddRangeAsync(continents);
                await dbContext.SaveChangesAsync();
            }

            // seed countries
            if (!await dbContext.Countries.AnyAsync())
            {
                var admin = dbContext.Users.FirstOrDefault(u => u.UserName == "admin") ?? throw new InvalidOperationException("Admin user not found");

                var countries = GetCountries(admin.Id);
                await dbContext.Countries.AddRangeAsync(countries);
                await dbContext.SaveChangesAsync();
            }

        }
    }

    private string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }

    // todo : add an admin user with details in the .env file
    private User GetAdminUser()
    {
        // todo: add to .env file
        string adminUsername = "admin";
        string adminPassword = "Password!23456";
        string adminEmail = "admin@email.com";

        // Hash the admin password (IMPORTANT!)
        string passwordHash = HashPassword(adminPassword);

        // Create the admin user
        var adminUser = new User
        {
            UserName = adminUsername,
            PasswordHash = passwordHash,
            Email = adminEmail,
        };

        return adminUser;
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
        [
            new(UserRoles.Admin) { NormalizedName = UserRoles.Admin.ToUpper() },
            new(UserRoles.Owner) { NormalizedName = UserRoles.Owner.ToUpper() },
            new(UserRoles.User) { NormalizedName = UserRoles.User.ToUpper() },
        ];

        return roles;
    }

    private IEnumerable<Continent> GetContinents(string adminId)
    {
        // https://datahub.io/core/continent-codes
        return
        [
            new Continent
            {
                Id = "AF",
                Name = "Africa",
                Description = "A vast and diverse continent known for its rich cultures, stunning wildlife, and historical significance as the cradle of humanity.",
                CreatedById = adminId,
            },
            new Continent
            {
                Id = "AN",
                Name = "Antartica",
                Description = "A remote, icy wilderness dedicated to science and exploration, home to extreme conditions and stunning polar beauty.",
                CreatedById = adminId,
            },
            new Continent
            {
                Id = "AS",
                Name = "Asia",
                Description = "The largest and most populous continent, home to ancient civilizations, booming economies, and breathtaking natural and urban landscapes.",
                CreatedById = adminId,
            },
            new Continent
            {
                Id = "EU",
                Name = "Europe",
                Description = "A continent steeped in history and art, blending medieval charm with modern innovation across a patchwork of nations.",
                CreatedById = adminId,
            },
            new Continent
            {
                Id = "NA",
                Name = "North America",
                Description = "A dynamic continent featuring cultural diversity, expansive landscapes, and global economic and technological influence.",
                CreatedById = adminId,
            },
            new Continent
            {
                Id = "OC",
                Name = "Oceania",
                Description = "A unique region with stunning biodiversity, indigenous heritage, and laid-back coastal lifestyles spread across islands and the Australian mainland.",
                CreatedById = adminId,
            },
            new Continent
            {
                Id = "SA",
                Name = "South America",
                Description = " A vibrant continent known for its natural wonders, passionate cultures, and a deep legacy of indigenous and colonial history.",
                CreatedById = adminId,
            },
        ];
    }
    private IEnumerable<Country> GetCountries(string adminId)
    {
        // https://en.wikipedia.org/wiki/List_of_ISO_3166_country_codes
        return
        [
            new Country
            {
                Id = "AF",
                Name = "Afghanistan",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "AL",
                Name = "Albania",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "DZ",
                Name = "Algeria",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "AD",
                Name = "Andorra",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "AO",
                Name = "Angola",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "AG",
                Name = "Antigua and Barbuda",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "AR",
                Name = "Argentina",
                Description = "A country in South America.",
                ContinentId = "SA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "AM",
                Name = "Armenia",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "AW",
                Name = "Aruba",
                Description = "A country in South America.",
                ContinentId = "SA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "AU",
                Name = "Australia",
                Description = "A country in Oceania.",
                ContinentId = "OC",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "AT",
                Name = "Austria",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "AZ",
                Name = "Azerbaijan",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BS",
                Name = "Bahamas",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BH",
                Name = "Bahrain",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BD",
                Name = "Bangladesh",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BB",
                Name = "Barbados",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BY",
                Name = "Belarus",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BE",
                Name = "Belgium",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BZ",
                Name = "Belize",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BJ",
                Name = "Benin",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BT",
                Name = "Bhutan",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BO",
                Name = "Bolivia",
                Description = "A country in South America.",
                ContinentId = "SA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BA",
                Name = "Bosnia and Herzegovina",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BW",
                Name = "Botswana",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BR",
                Name = "Brazil",
                Description = "A country in South America.",
                ContinentId = "SA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BN",
                Name = "Brunei",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BG",
                Name = "Bulgaria",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BF",
                Name = "Burkina Faso",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "BI",
                Name = "Burundi",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "CV",
                Name = "Cabo Verde",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "KH",
                Name = "Cambodia",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "CM",
                Name = "Cameroon",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "CA",
                Name = "Canada",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "CF",
                Name = "Central African Republic",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "TD",
                Name = "Chad",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "CL",
                Name = "Chile",
                Description = "A country in South America.",
                ContinentId = "SA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "CN",
                Name = "China",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "CO",
                Name = "Colombia",
                Description = "A country in South America.",
                ContinentId = "SA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "KM",
                Name = "Comoros",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "CD",
                Name = "Congo, Democratic Republic of the",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "CG",
                Name = "Congo, Republic of the",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "CR",
                Name = "Costa Rica",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "HR",
                Name = "Croatia",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "CU",
                Name = "Cuba",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "CY",
                Name = "Cyprus",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "CZ",
                Name = "Czechia",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "DK",
                Name = "Denmark",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "DJ",
                Name = "Djibouti",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "DM",
                Name = "Dominica",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "DO",
                Name = "Dominican Republic",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "EC",
                Name = "Ecuador",
                Description = "A country in South America.",
                ContinentId = "SA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "EG",
                Name = "Egypt",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SV",
                Name = "El Salvador",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "GQ",
                Name = "Equatorial Guinea",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "ER",
                Name = "Eritrea",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "EE",
                Name = "Estonia",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SZ",
                Name = "Eswatini",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "ET",
                Name = "Ethiopia",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "FJ",
                Name = "Fiji",
                Description = "A country in Oceania.",
                ContinentId = "OC",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "FI",
                Name = "Finland",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "FR",
                Name = "France",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "GA",
                Name = "Gabon",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "GM",
                Name = "Gambia",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "GE",
                Name = "Georgia",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "DE",
                Name = "Germany",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "GH",
                Name = "Ghana",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "GR",
                Name = "Greece",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "GD",
                Name = "Grenada",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "GT",
                Name = "Guatemala",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "GN",
                Name = "Guinea",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "GW",
                Name = "Guinea-Bissau",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "GY",
                Name = "Guyana",
                Description = "A country in South America.",
                ContinentId = "SA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "HT",
                Name = "Haiti",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "HN",
                Name = "Honduras",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "HU",
                Name = "Hungary",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "IS",
                Name = "Iceland",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "IN",
                Name = "India",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "ID",
                Name = "Indonesia",
                Description = "A country in Asia/Oceania.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "IR",
                Name = "Iran",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "IQ",
                Name = "Iraq",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "IE",
                Name = "Ireland",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "IL",
                Name = "Israel",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "IT",
                Name = "Italy",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "JM",
                Name = "Jamaica",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "JP",
                Name = "Japan",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "JO",
                Name = "Jordan",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "KZ",
                Name = "Kazakhstan",
                Description = "A country in Asia/Europe.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "KE",
                Name = "Kenya",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "KI",
                Name = "Kiribati",
                Description = "A country in Oceania.",
                ContinentId = "OC",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "KP",
                Name = "Korea, North",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "KR",
                Name = "Korea, South",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "XK",
                Name = "Kosovo",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "KW",
                Name = "Kuwait",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "KG",
                Name = "Kyrgyzstan",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "LA",
                Name = "Laos",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "LV",
                Name = "Latvia",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "LB",
                Name = "Lebanon",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "LS",
                Name = "Lesotho",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "LR",
                Name = "Liberia",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "LY",
                Name = "Libya",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "LI",
                Name = "Liechtenstein",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "LT",
                Name = "Lithuania",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "LU",
                Name = "Luxembourg",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "MG",
                Name = "Madagascar",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "MW",
                Name = "Malawi",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "MY",
                Name = "Malaysia",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "MV",
                Name = "Maldives",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "ML",
                Name = "Mali",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "MT",
                Name = "Malta",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "MH",
                Name = "Marshall Islands",
                Description = "A country in Oceania.",
                ContinentId = "OC",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "MR",
                Name = "Mauritania",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "MU",
                Name = "Mauritius",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "MX",
                Name = "Mexico",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "FM",
                Name = "Micronesia, Federated States of",
                Description = "A country in Oceania.",
                ContinentId = "OC",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "MD",
                Name = "Moldova",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "MC",
                Name = "Monaco",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "MN",
                Name = "Mongolia",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "ME",
                Name = "Montenegro",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "MA",
                Name = "Morocco",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "MZ",
                Name = "Mozambique",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "MM",
                Name = "Myanmar",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "NA",
                Name = "Namibia",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "NR",
                Name = "Nauru",
                Description = "A country in Oceania.",
                ContinentId = "OC",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "NP",
                Name = "Nepal",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "NL",
                Name = "Netherlands",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "NZ",
                Name = "New Zealand",
                Description = "A country in Oceania.",
                ContinentId = "OC",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "NI",
                Name = "Nicaragua",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "NE",
                Name = "Niger",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "NG",
                Name = "Nigeria",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "MK",
                Name = "North Macedonia",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "NO",
                Name = "Norway",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "OM",
                Name = "Oman",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "PK",
                Name = "Pakistan",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "PW",
                Name = "Palau",
                Description = "A country in Oceania.",
                ContinentId = "OC",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "PA",
                Name = "Panama",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "PG",
                Name = "Papua New Guinea",
                Description = "A country in Oceania.",
                ContinentId = "OC",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "PY",
                Name = "Paraguay",
                Description = "A country in South America.",
                ContinentId = "SA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "PE",
                Name = "Peru",
                Description = "A country in South America.",
                ContinentId = "SA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "PH",
                Name = "Philippines",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "PL",
                Name = "Poland",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "PT",
                Name = "Portugal",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "QA",
                Name = "Qatar",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "RO",
                Name = "Romania",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "RU",
                Name = "Russia",
                Description = "A country in Europe/Asia.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "RW",
                Name = "Rwanda",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "KN",
                Name = "Saint Kitts and Nevis",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "LC",
                Name = "Saint Lucia",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "VC",
                Name = "Saint Vincent and the Grenadines",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "WS",
                Name = "Samoa",
                Description = "A country in Oceania.",
                ContinentId = "OC",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SM",
                Name = "San Marino",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "ST",
                Name = "Sao Tome and Principe",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SA",
                Name = "Saudi Arabia",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SN",
                Name = "Senegal",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "RS",
                Name = "Serbia",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SC",
                Name = "Seychelles",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SL",
                Name = "Sierra Leone",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SG",
                Name = "Singapore",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SK",
                Name = "Slovakia",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SI",
                Name = "Slovenia",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SB",
                Name = "Solomon Islands",
                Description = "A country in Oceania.",
                ContinentId = "OC",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SO",
                Name = "Somalia",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "ZA",
                Name = "South Africa",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SS",
                Name = "South Sudan",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "ES",
                Name = "Spain",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "LK",
                Name = "Sri Lanka",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SD",
                Name = "Sudan",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SR",
                Name = "Suriname",
                Description = "A country in South America.",
                ContinentId = "SA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SE",
                Name = "Sweden",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "CH",
                Name = "Switzerland",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "SY",
                Name = "Syria",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "TW",
                Name = "Taiwan",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "TJ",
                Name = "Tajikistan",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "TZ",
                Name = "Tanzania",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "TH",
                Name = "Thailand",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "TL",
                Name = "Timor-Leste",
                Description = "A country in Asia/Oceania.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "TG",
                Name = "Togo",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "TO",
                Name = "Tonga",
                Description = "A country in Oceania.",
                ContinentId = "OC",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "TT",
                Name = "Trinidad and Tobago",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "TN",
                Name = "Tunisia",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "TR",
                Name = "Turkey",
                Description = "A country in Europe/Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "TM",
                Name = "Turkmenistan",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "TV",
                Name = "Tuvalu",
                Description = "A country in Oceania.",
                ContinentId = "OC",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "UG",
                Name = "Uganda",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "UA",
                Name = "Ukraine",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "AE",
                Name = "United Arab Emirates",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "GB",
                Name = "United Kingdom",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "US",
                Name = "United States of America",
                Description = "A country in North America.",
                ContinentId = "NA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "UY",
                Name = "Uruguay",
                Description = "A country in South America.",
                ContinentId = "SA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "UZ",
                Name = "Uzbekistan",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "VU",
                Name = "Vanuatu",
                Description = "A country in Oceania.",
                ContinentId = "OC",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "VA",
                Name = "Vatican City",
                Description = "A country in Europe.",
                ContinentId = "EU",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "VE",
                Name = "Venezuela",
                Description = "A country in South America.",
                ContinentId = "SA",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "VN",
                Name = "Vietnam",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "YE",
                Name = "Yemen",
                Description = "A country in Asia.",
                ContinentId = "AS",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "ZM",
                Name = "Zambia",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            },
            new Country
            {
                Id = "ZW",
                Name = "Zimbabwe",
                Description = "A country in Africa.",
                ContinentId = "AF",
                CreatedById = adminId,
            }
        ];
    }
}
