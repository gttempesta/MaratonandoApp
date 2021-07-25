using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaratonandoApp.Server.Data;
using MaratonandoApp.Shared.Models.Series;
using MaratonandoApp.Shared.Resources;
using MaratonandoApp.Server.Utils;

namespace MaratonandoApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SeriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Series
        [HttpGet]
        public async Task<ActionResult<List<Serie>>> GetSerie([FromQuery] Paginacao paginacao, [FromQuery] string titulo)
        {
            var queryable = _context.Series.AsQueryable();

            if (!string.IsNullOrEmpty(titulo))
            {
                queryable = queryable.Where(x => x.Titulo.Contains(titulo));
            }

            await HttpContext.InserirParametroEmPageResponse(queryable, paginacao.QuantidadePorPagina);

            return await queryable.Paginar(paginacao).ToListAsync();
        }

        // GET: api/Series/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Serie>> GetSerie(int id)
        {
            var serie = await _context.Series.FindAsync(id);

            if (serie == null)
            {
                return NotFound();
            }

            return serie;
        }

        // PUT: api/Series/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSerie(int id, Serie serie)
        {
            if (id != serie.SerieId)
            {
                return BadRequest();
            }

            _context.Entry(serie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerieExists(id))
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

        // POST: api/Series
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Serie>> PostSerie(Serie serie)
        {
            _context.Series.Add(serie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSerie", new { id = serie.SerieId }, serie);
        }

        // DELETE: api/Series/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerie(int id)
        {
            var serie = await _context.Series.FindAsync(id);
            if (serie == null)
            {
                return NotFound();
            }

            _context.Series.Remove(serie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SerieExists(int id)
        {
            return _context.Series.Any(e => e.SerieId == id);
        }
    }
}
