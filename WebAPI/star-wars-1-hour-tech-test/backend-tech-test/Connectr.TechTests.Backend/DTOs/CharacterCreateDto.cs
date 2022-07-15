using Connectr.TechTests.Backend.EntityFramework.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Connectr.TechTests.Backend.Controllers
{
    public class CharacterCreateDto
    {
        [Required]
        public string Name { get; set; }

        public string BirthYear { get; set; }

        [Required]
        public Species Species { get; set; }

        [Required]
        public List<Film> Films { get; set; }

    }
}