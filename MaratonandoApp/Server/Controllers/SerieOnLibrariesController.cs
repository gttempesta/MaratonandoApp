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
    public class SerieOnLibrariesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SerieOnLibrariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SerieOnLibraries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SerieOnLibrary>>> GetSerieOnLibrary()
        {
            return await _context.SerieOnLibrary.ToListAsync();
        }

        // GET: api/SerieOnLibraries/getSerieLibrary/ids
        [HttpGet("getSerieLibrary/{id}/{ids}")]
        public async Task<ActionResult<SerieOnLibrary>> getSerieLibrary(int id, int ids)
        {
            var seriesOnLibraries = await _context.SerieOnLibrary.ToListAsync();

            foreach (var sol in seriesOnLibraries)
            {
                if (sol.SerieLibraryId == id && sol.SerieId == ids)
                {
                    return sol;
                }
            }

            return new SerieOnLibrary();
        }

        // GET: api/SerieOnLibraries/getSerieOnLibraryWithASL/id
        [HttpGet("getSerieOnLibraryWithASL/{id}")]
        public async Task<ActionResult<IEnumerable<SerieOnLibrary>>> getSerieOnLibraryWithASL(int id)
        {
            var response = await _context.SerieOnLibrary.ToListAsync();
            List<SerieOnLibrary> seriesonlib = new();

            foreach (var sol in response)
            {
                if (sol.SerieLibraryId == id)
                {
                    seriesonlib.Add(sol);
                }
            }

            return seriesonlib;
        }

        // GET: api/SerieOnLibraries/getSerieOnLibraryWithASLAssist/id
        [HttpGet("getSerieOnLibraryWithASL/{id}/status/{status}")]
        public async Task<ActionResult<IEnumerable<SerieOnLibrary>>> getSerieOnLibraryWithASLAssist(int id, int status)
        {
            var response = await _context.SerieOnLibrary.ToListAsync();
            List<SerieOnLibrary> seriesonlib = new();

            foreach (var sol in response)
            {
                if (sol.SerieLibraryId == id && sol.SeriesStatus == status)
                {
                    seriesonlib.Add(sol);
                }
            }

            return seriesonlib;
        }

        // GET: api/SerieOnLibraries/getQuantidadeSerie/id
        [HttpGet("getQuantidadeSerie/{id}/{status}")]
        public async Task<ActionResult<int>> getQuantidadeSerie(int id, int status)
        {
            var seriesOnLibraries = await _context.SerieOnLibrary.ToListAsync();
            int quantidade = 0;

            foreach (var sol in seriesOnLibraries)
            {
                if (sol.SerieLibraryId == id && sol.SeriesStatus == status)
                {
                    quantidade++;
                }
            }

            return quantidade;
        }

        // GET: api/SerieOnLibraries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SerieOnLibrary>> GetSerieOnLibrary(int id)
        {
            var serieOnLibrary = await _context.SerieOnLibrary.FindAsync(id);

            if (serieOnLibrary == null)
            {
                return NotFound();
            }

            return serieOnLibrary;
        }

        // PUT: api/SerieOnLibraries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSerieOnLibrary(int id, SerieOnLibrary serieOnLibrary)
        {
            if (id != serieOnLibrary.SerieOnLibraryId)
            {
                return BadRequest();
            }

            _context.Entry(serieOnLibrary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerieOnLibraryExists(id))
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

        // POST: api/SerieOnLibraries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SerieOnLibrary>> PostSerieOnLibrary(SerieOnLibrary serieOnLibrary)
        {
            _context.SerieOnLibrary.Add(serieOnLibrary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSerieOnLibrary", new { id = serieOnLibrary.SerieOnLibraryId }, serieOnLibrary);
        }

        // DELETE: api/SerieOnLibraries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerieOnLibrary(int id)
        {
            var serieOnLibrary = await _context.SerieOnLibrary.FindAsync(id);
            if (serieOnLibrary == null)
            {
                return NotFound();
            }

            _context.SerieOnLibrary.Remove(serieOnLibrary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SerieOnLibraryExists(int id)
        {
            return _context.SerieOnLibrary.Any(e => e.SerieOnLibraryId == id);
        }
    }
}
