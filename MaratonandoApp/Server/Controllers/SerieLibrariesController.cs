using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaratonandoApp.Server.Data;
using MaratonandoApp.Shared.Models.Series;
using MaratonandoApp.Shared.Models.User;

namespace MaratonandoApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieLibrariesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SerieLibrariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SerieLibraries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SerieLibrary>>> GetSerieLibrary()
        {
            return await _context.SerieLibrary.ToListAsync();
        }

        // GET: api/SerieLibraries/getUserLoadSerie
        [HttpGet("getUserLoadSerie/{id}")]
        public async Task<ActionResult<SerieLibrary>> GetUserSerieLibrary(string id)
        {
            var serieLibraries = await _context.SerieLibrary.ToListAsync();
            SerieLibrary serielib = new();

            foreach (var sl in serieLibraries)
            {
                if (sl.UserId.Equals(id))
                {
                    serielib = sl;
                }
            }

            return serielib;
        }

        // GET: api/SerieLibraries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SerieLibrary>> GetSerieLibrary(int id)
        {
            var serieLibrary = await _context.SerieLibrary.FindAsync(id);

            if (serieLibrary == null)
            {
                return NotFound();
            }

            return serieLibrary;
        }

        // PUT: api/SerieLibraries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSerieLibrary(int id, SerieLibrary serieLibrary)
        {
            if (id != serieLibrary.SerieLibraryId)
            {
                return BadRequest();
            }

            _context.Entry(serieLibrary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerieLibraryExists(id))
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

        // POST: api/SerieLibraries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SerieLibrary>> PostSerieLibrary(SerieLibrary serieLibrary)
        {
            _context.SerieLibrary.Add(serieLibrary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSerieLibrary", new { id = serieLibrary.SerieLibraryId }, serieLibrary);
        }

        // DELETE: api/SerieLibraries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerieLibrary(int id)
        {
            var serieLibrary = await _context.SerieLibrary.FindAsync(id);
            if (serieLibrary == null)
            {
                return NotFound();
            }

            _context.SerieLibrary.Remove(serieLibrary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SerieLibraryExists(int id)
        {
            return _context.SerieLibrary.Any(e => e.SerieLibraryId == id);
        }
    }
}
