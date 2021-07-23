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
    public class FilmCommentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FilmCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FilmComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmComment>>> GetFilmComment()
        {
            return await _context.FilmComment.ToListAsync();
        }

        // GET: api/FilmComments/GetFilmCommentByFilm
        [HttpGet("GetFilmCommentByFilm/{id}")]
        public async Task<ActionResult<IEnumerable<FilmComment>>> GetFilmCommentByFilm(int id)
        {
            List<FilmComment> filmComments =  await _context.FilmComment.ToListAsync();

            List<FilmComment> filmsCommentsByMovies = new List<FilmComment>();

            foreach (var fc in filmComments)
            {
                if (fc.FilmId == id)
                {
                    filmsCommentsByMovies.Add(fc);
                }
            }

            return filmsCommentsByMovies;
        }

        // GET: api/FilmComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmComment>> GetFilmComment(int id)
        {
            var filmComment = await _context.FilmComment.FindAsync(id);

            if (filmComment == null)
            {
                return NotFound();
            }

            return filmComment;
        }

        // PUT: api/FilmComments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmComment(int id, FilmComment filmComment)
        {
            if (id != filmComment.FilmCommentId)
            {
                return BadRequest();
            }

            _context.Entry(filmComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmCommentExists(id))
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

        // POST: api/FilmComments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmComment>> PostFilmComment(FilmComment filmComment)
        {
            _context.FilmComment.Add(filmComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmComment", new { id = filmComment.FilmCommentId }, filmComment);
        }

        // DELETE: api/FilmComments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmComment(int id)
        {
            var filmComment = await _context.FilmComment.FindAsync(id);
            if (filmComment == null)
            {
                return NotFound();
            }

            _context.FilmComment.Remove(filmComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmCommentExists(int id)
        {
            return _context.FilmComment.Any(e => e.FilmCommentId == id);
        }
    }
}
