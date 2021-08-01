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
    public class EpisodeOnLibrariesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EpisodeOnLibrariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EpisodeOnLibraries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EpisodeOnLibrary>>> GetEpisodeOnLibrary()
        {
            return await _context.EpisodeOnLibrary.ToListAsync();
        }

        // GET: api/EpisodeOnLibraries
        [HttpGet("GetEpisodesBySeriesChecked/{id}")]
        public async Task<ActionResult<IEnumerable<EpisodeOnLibrary>>> GetEpisodesBySeriesChecked(int id)
        {
            return await _context.EpisodeOnLibrary.Where<EpisodeOnLibrary>(eol => eol.EpisodeLibraryId == id).ToListAsync();
        }

        // GET: api/EpisodeOnLibraries/5
        [HttpGet("getEpOnLib/{id}/{ideol}")]
        public async Task<ActionResult<EpisodeOnLibrary>> getEpOnLib(int id, int ideol)
        {
            var episodeOnLibrary = await _context.EpisodeOnLibrary.FindAsync(ideol, id);

            if (episodeOnLibrary == null)
            {
                episodeOnLibrary = new();
                return episodeOnLibrary;
            }

            return episodeOnLibrary;
        }

        // PUT: api/EpisodeOnLibraries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/{ideol}")]
        public async Task<IActionResult> PutEpisodeOnLibrary(int id, int ideol, EpisodeOnLibrary episodeOnLibrary)
        {
            if (ideol != episodeOnLibrary.EpisodeLibraryId && id != episodeOnLibrary.EpisodeId)
            {
                return BadRequest();
            }

            _context.Entry(episodeOnLibrary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpisodeOnLibraryExists(id))
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

        // POST: api/EpisodeOnLibraries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EpisodeOnLibrary>> PostEpisodeOnLibrary(EpisodeOnLibrary episodeOnLibrary)
        {
            _context.EpisodeOnLibrary.Add(episodeOnLibrary);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EpisodeOnLibraryExists(episodeOnLibrary.EpisodeLibraryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEpisodeOnLibrary", new { id = episodeOnLibrary.EpisodeLibraryId }, episodeOnLibrary);
        }

        // DELETE: api/EpisodeOnLibraries/5
        [HttpDelete("{id}/{ideol}")]
        public async Task<IActionResult> DeleteEpisodeOnLibrary(int id, int ideol)
        {
            var episodeOnLibrary = await _context.EpisodeOnLibrary.FindAsync(ideol, id);
            if (episodeOnLibrary == null)
            {
                return NotFound();
            }

            _context.EpisodeOnLibrary.Remove(episodeOnLibrary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EpisodeOnLibraryExists(int id)
        {
            return _context.EpisodeOnLibrary.Any(e => e.EpisodeLibraryId == id);
        }
    }
}
