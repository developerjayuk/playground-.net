using System.Collections.Generic;

namespace Connectr.TechTests.Backend.Controllers
{
    public class FilmResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<string> Characters { get; set; }

        public List<string> Planets { get; set; }

        public List<string> Species { get; set; }

    }
}