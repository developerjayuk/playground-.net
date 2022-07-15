namespace Connectr.TechTests.Backend.Models
{
    public class FilterModel
    {
        public string Species { get; set; }
        public string Planet { get; set; }
        public int Page { get; set; } = 1; // default to page 1
        public int Limit { get; set; } = 5; // default page limit of 5

    }
}
