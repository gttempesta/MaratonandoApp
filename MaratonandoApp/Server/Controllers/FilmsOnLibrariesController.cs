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
    public class FilmsOnLibrariesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FilmsOnLibrariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FilmsOnLibraries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmsOnLibrary>>> GetFilmsOnLibraries()
        {
            return await _context.FilmsOnLibraries.ToListAsync();
        }

        // GET: api/FilmsOnLibraries/GetFOLWithFL/1
        [HttpGet("GetFOLWithFL/{id}")]
        public async Task<ActionResult<IEnumerable<FilmsOnLibrary>>> GetFOLWithFL(int id)
        {
            return await _context.FilmsOnLibraries.Where<FilmsOnLibrary>(fol => fol.FilmLibraryId == id).ToListAsync();
        }

        // GET: api/FilmsOnLibraries/GetFilmsOnLibrariesByFLFave/1
        [HttpGet("GetFilmsOnLibrariesByFLFave/{id}")]
        public async Task<ActionResult<IEnumerable<FilmsOnLibrary>>> GetFilmsOnLibrariesByFLFave(int id)
        {
            return await _context.FilmsOnLibraries.Where<FilmsOnLibrary>(fol => fol.FilmLibraryId == id && fol.FlFavorito).ToListAsync();
        }

        // GET: api/FilmsOnLibraries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmsOnLibrary>> GetFilmsOnLibrary(int id)
        {
            var filmsOnLibrary = await _context.FilmsOnLibraries.FindAsync(id);

            if (filmsOnLibrary == null)
            {
                return NotFound();
            }

            return filmsOnLibrary;
        }

        // GET: api/FilmsOnLibraries/getFilmLibrary/id/idf
        [HttpGet("getFilmLibrary/{id}/{idf}")]
        public async Task<ActionResult<FilmsOnLibrary>> getFilmLibrary(int id, int idf)
        {
            var filmsOnLibrary = await _context.FilmsOnLibraries.ToListAsync();

            foreach(var fol in filmsOnLibrary)
            {
                if (fol.FilmLibraryId == id && fol.FilmId == idf)
                {
                    return fol;
                }
            }

            return new FilmsOnLibrary();
        }

        // GET: api/FilmsOnLibraries
        [HttpGet("getQtdFilmesVisto/{id}")]
        public async Task<ActionResult<int>> getQtdFilmesVisto(int id)
        {
            var retorno =  await _context.FilmsOnLibraries.ToListAsync();
            int quantidade = 0;

            foreach (var fl in retorno)
            {
                if (fl.FilmLibraryId == id && fl.FlAssistido)
                {
                    quantidade++;
                }
            }

            return quantidade;
        }

        // PUT: api/FilmsOnLibraries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmsOnLibrary(int id, FilmsOnLibrary filmsOnLibrary)
        {
            if (id != filmsOnLibrary.FilmLibraryId)
            {
                return BadRequest();
            }

            _context.Entry(filmsOnLibrary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmsOnLibraryExists(id))
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

        // POST: api/FilmsOnLibraries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmsOnLibrary>> PostFilmsOnLibrary(FilmsOnLibrary filmsOnLibrary)
        {
            _context.FilmsOnLibraries.Add(filmsOnLibrary);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FilmsOnLibraryExists(filmsOnLibrary.FilmLibraryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFilmsOnLibrary", new { id = filmsOnLibrary.FilmLibraryId }, filmsOnLibrary);
        }

        // DELETE: api/FilmsOnLibraries/5
        [HttpDelete("{id}/{idfl}")]
        public async Task<IActionResult> DeleteFilmsOnLibrary(int id, int idfl)
        {
            var filmsOnLibrary = await _context.FilmsOnLibraries.FindAsync(idfl, id);
            if (filmsOnLibrary == null)
            {
                return NotFound();
            }

            _context.FilmsOnLibraries.Remove(filmsOnLibrary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmsOnLibraryExists(int id)
        {
            return _context.FilmsOnLibraries.Any(e => e.FilmLibraryId == id);
        }
    }
}
