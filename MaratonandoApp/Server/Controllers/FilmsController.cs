using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaratonandoApp.Server.Data;
using MaratonandoApp.Shared.Models.Film;
using MaratonandoApp.Shared.Resources;
using MaratonandoApp.Server.Utils;

namespace MaratonandoApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FilmsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Films
        [HttpGet]
        public async Task<ActionResult<List<Film>>> GetFilms([FromQuery] Paginacao paginacao, [FromQuery] string titulo)
        {
            var queryable = _context.Films.AsQueryable();

            if (!string.IsNullOrEmpty(titulo))
            {
                queryable = queryable.Where(x => x.Titulo.Contains(titulo));

            }
            await HttpContext.InserirParametroEmPageResponse(queryable, paginacao.QuantidadePorPagina);
            return await queryable.Paginar(paginacao).ToListAsync();
            
        }

        // GET: api/Films/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Film>> GetFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);

            if (film == null)
            {
                return NotFound();
            }

            return film;
        }

        //// PUT: api/Films/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutFilm(int id, Film film)
        //{
        //    if (id != film.FilmId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(film).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FilmExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Films
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Film>> PostFilm(Film film)
        //{
        //    _context.Films.Add(film);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetFilm", new { id = film.FilmId }, film);
        //}

        //// DELETE: api/Films/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteFilm(int id)
        //{
        //    var film = await _context.Films.FindAsync(id);
        //    if (film == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Films.Remove(film);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e => e.FilmId == id);
        }
    }
}
