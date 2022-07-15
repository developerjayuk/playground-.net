using Connectr.TechTests.Backend.EntityFramework;
using Connectr.TechTests.Backend.EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connectr.TechTests.Backend.Controllers
{
    public class CharactersController : BaseApiController
    {
        private readonly StarwarsDbContext _context;
        public CharactersController(StarwarsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET /api/characters
        /// get all characters 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<CharacterResponseDto>>>
            GetCharactersAsync()
        {
            var characters = await _context.Characters
                .Select(c =>
                new CharacterResponseDto()
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthYear = c.BirthYear,
                    Species = c.Species.Select(s => s.Name).First() ?? "unknown",
                    Films = c.Films.Select(f => f.Title).ToList(),

                }).ToListAsync();

            return Ok(characters);
        }

        /// <summary>
        /// GET /api/characters/{id}
        /// get character by Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponseDto>> GetCharacterAsync(int id)
        {
            var character = await _context.Characters
                .Select(c =>
                new CharacterResponseDto()
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthYear = c.BirthYear,
                    Species = c.Species.Select(s => s.Name).First() ?? "unknown",
                    Films = c.Films.Select(f => f.Title).ToList(),

                }).SingleOrDefaultAsync(c => c.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        /// <summary>
        /// POST /api/characters/
        /// create new character
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult>CreateCharacter(CharacterCreateDto character)
        {
            Character newCharacter = new()
            {
                Name = character.Name,
                BirthYear = character.BirthYear,
            };

            // check species exists
            var species = _context.Species.Where(s => s.Id == character.Species.Id).ToList();
            if (!species.Any())
                return BadRequest();
            newCharacter.Species = species;

            // check films exists
            var filmIds = character.Films.Select(f => f.Id).ToList();
            var films = _context.Films.Where(f => filmIds.Contains(f.Id)).ToList();
            if (!films.Any())
                return BadRequest();
            newCharacter.Films = films;

            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();
 
            return NoContent();
        }
    }
}
