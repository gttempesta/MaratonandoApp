using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaratonandoApp.Server.Data;
using MaratonandoApp.Shared.Models.Series;

namespace MaratonandoApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeLibrariesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EpisodeLibrariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EpisodeLibraries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EpisodeLibrary>>> GetEpisodeLibrary()
        {
            return await _context.EpisodeLibrary.ToListAsync();
        }

        // GET: api/EpisodeLibraries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EpisodeLibrary>> GetEpisodeLibrary(int id)
        {
            var episodeLibrary = await _context.EpisodeLibrary.FindAsync(id);

            if (episodeLibrary == null)
            {
                return NotFound();
            }

            return episodeLibrary;
        }

        // PUT: api/EpisodeLibraries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEpisodeLibrary(int id, EpisodeLibrary episodeLibrary)
        {
            if (id != episodeLibrary.EpisodeLibraryId)
            {
                return BadRequest();
            }

            _context.Entry(episodeLibrary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpisodeLibraryExists(id))
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

        // POST: api/EpisodeLibraries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EpisodeLibrary>> PostEpisodeLibrary(EpisodeLibrary episodeLibrary)
        {
            _context.EpisodeLibrary.Add(episodeLibrary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEpisodeLibrary", new { id = episodeLibrary.EpisodeLibraryId }, episodeLibrary);
        }

        // DELETE: api/EpisodeLibraries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEpisodeLibrary(int id)
        {
            var episodeLibrary = await _context.EpisodeLibrary.FindAsync(id);
            if (episodeLibrary == null)
            {
                return NotFound();
            }

            _context.EpisodeLibrary.Remove(episodeLibrary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EpisodeLibraryExists(int id)
        {
            return _context.EpisodeLibrary.Any(e => e.EpisodeLibraryId == id);
        }
    }
}
