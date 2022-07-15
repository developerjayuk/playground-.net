using System.Collections.Generic;

namespace Connectr.TechTests.Backend.Models
{
    public class PagedItemsResponse<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
