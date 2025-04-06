
namespace WorldTravel.Domain.Entities
{
    public class Continent
    {
        public int Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public List<Country> Countries { get; set; } = new();
    }
}
