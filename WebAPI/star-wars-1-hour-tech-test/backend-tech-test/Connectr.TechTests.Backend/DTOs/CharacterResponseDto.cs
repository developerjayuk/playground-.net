using System.Collections.Generic;

namespace Connectr.TechTests.Backend.Controllers
{
    public class CharacterResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BirthYear { get; set; }

        public string Species { get; set; }

        public List<string> Films { get; set; }

    }
}