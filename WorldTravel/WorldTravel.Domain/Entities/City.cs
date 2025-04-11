
namespace WorldTravel.Domain.Entities
{
    public class City
    {
        public int Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string CountryId { get; set; } = default!;
    }
}
