
namespace WorldTravel.Domain.Entities
{
    public class Continent
    {
        // set as ISO Code
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public List<Country> Countries { get; set; } = new();
        public User CreatedBy { get; set; } = default!;
        public string CreatedById { get; set; } = default!;
    }
}
