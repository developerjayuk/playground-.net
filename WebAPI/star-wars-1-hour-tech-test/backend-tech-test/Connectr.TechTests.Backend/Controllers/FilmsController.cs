using Connectr.TechTests.Backend.EntityFramework;
using Connectr.TechTests.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connectr.TechTests.Backend.Controllers
{
    public class FilmsController : BaseApiController
    {
        private readonly StarwarsDbContext _context;
        public FilmsController(StarwarsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET /api/films
        /// get all films 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PagedItemsResponse<FilmResponseDto>>>
            GetFilmsAsync([FromQuery] FilterModel filter)
        {
            var films = await _context.Films
                .Select(f =>
                new FilmResponseDto()
                {
                    Id = f.Id,
                    Title = f.Title,
                    Characters = f.Characters.Select(c => c.Name).ToList(),
                    Planets = f.Planets.Select(p => p.Name).ToList(),
                    Species = f.Species.Select(s => s.Name).ToList(),
                }).ToListAsync();

            if (!films.Any())
                return NotFound();

            // filter results
            if (filter.Species != null)
            {
                films = films
                    .Where(f => f.Species
                        .ConvertAll(f => f.ToLower())
                        .Contains(filter.Species.ToLower()))
                    .ToList();
                if (!films.Any())
                    return NotFound(new ErrorResponse() { Error = $"No Films found for the species '{filter.Species}'" });
            }

            if (filter.Planet != null)
            {
                films = films
                    .Where(f => f.Planets
                        .ConvertAll(f => f.ToLower())
                        .Contains(filter.Planet.ToLower()))
                    .ToList();
                if (!films.Any())
                    return NotFound(new ErrorResponse() { Error = $"No Films found for the planet '{filter.Planet}'" });

            }

            // apply paging to filtered results
            var totalFiltered = films.Count;
            films = films
                .Skip((filter.Page - 1) * filter.Limit)
                .Take(filter.Limit).ToList();

            if (!films.Any())
                return NotFound(new ErrorResponse() { Error = $"No Films found for page '{filter.Page}'" });


            var pagedItems = new PagedItemsResponse<FilmResponseDto>()
            {
                Items = films,
                TotalItems = totalFiltered,
                ItemsPerPage = filter.Limit,
                CurrentPage = filter.Page,
                TotalPages = (totalFiltered + filter.Limit - 1) / filter.Limit
            };

            return Ok(pagedItems);
        }

        /// <summary>
        /// GET /api/films/{id}
        /// get a film by Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<FilmResponseDto>>> GetFilmAsync(int id)
        {
            var film = await _context.Films
                .Select(f =>
                new FilmResponseDto()
                {
                    Id = f.Id,
                    Title = f.Title,
                    Characters = f.Characters.Select(c => c.Name).ToList(),
                    Planets = f.Planets.Select(p => p.Name).ToList(),
                    Species = f.Species.Select(s => s.Name).ToList(),
                }).SingleOrDefaultAsync(f => f.Id == id);

            if (film == null)
                return NotFound();

            return Ok(film);
        }
    }
}
