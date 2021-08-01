using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaratonandoApp.Server.Data;
using MaratonandoApp.Shared.Models.Film;

namespace MaratonandoApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmLibrariesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FilmLibrariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FilmLibraries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmLibrary>>> GetFilmLibraries()
        {
            return await _context.FilmLibraries.ToListAsync();
        }

        // GET: api/FilmLibraries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmLibrary>> GetFilmLibrary(string id)
        {
            var filmLibraries = await _context.FilmLibraries.ToListAsync();

            foreach (var filmLibrary in filmLibraries)
            {
                if (filmLibrary.UserId.Equals(id))
                {
                    return filmLibrary;
                }
            }

            return new FilmLibrary();
        }

        // PUT: api/FilmLibraries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmLibrary(int id, FilmLibrary filmLibrary)
        {
            if (id != filmLibrary.FilmLibraryId)
            {
                return BadRequest();
            }

            _context.Entry(filmLibrary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmLibraryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FilmLibraries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmLibrary>> PostFilmLibrary(FilmLibrary filmLibrary)
        {
            _context.FilmLibraries.Add(filmLibrary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmLibrary", new { id = filmLibrary.FilmLibraryId }, filmLibrary);
        }

        // DELETE: api/FilmLibraries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmLibrary(int id)
        {
            var filmLibrary = await _context.FilmLibraries.FindAsync(id);
            if (filmLibrary == null)
            {
                return NotFound();
            }

            _context.FilmLibraries.Remove(filmLibrary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmLibraryExists(int id)
        {
            return _context.FilmLibraries.Any(e => e.FilmLibraryId == id);
        }
    }
}
