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
    public class EpisodeCommentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EpisodeCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EpisodeComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EpisodeComment>>> GetEpisodeComment()
        {
            return await _context.EpisodeComment.ToListAsync();
        }

        // GET: api/EpisodeComments/GetCommentsCommentByEp
        [HttpGet("GetCommentsCommentByEp/{id}")]
        public async Task<ActionResult<IEnumerable<EpisodeComment>>> GetCommentsCommentByEp(int id)
        {
            List<EpisodeComment> episodeComments = await _context.EpisodeComment.ToListAsync();

            List<EpisodeComment> episodeCommentsbySpec = new();

            foreach (var ec in episodeComments)
            {
                if (ec.EpisodeId == id)
                {
                    episodeCommentsbySpec.Add(ec);
                }
            }

            return episodeCommentsbySpec;
        }

        // GET: api/EpisodeComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EpisodeComment>> GetEpisodeComment(int id)
        {
            var episodeComment = await _context.EpisodeComment.FindAsync(id);

            if (episodeComment == null)
            {
                return NotFound();
            }

            return episodeComment;
        }

        // PUT: api/EpisodeComments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEpisodeComment(int id, EpisodeComment episodeComment)
        {
            if (id != episodeComment.EpisodeCommentId)
            {
                return BadRequest();
            }

            _context.Entry(episodeComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpisodeCommentExists(id))
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

        // POST: api/EpisodeComments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EpisodeComment>> PostEpisodeComment(EpisodeComment episodeComment)
        {
            _context.EpisodeComment.Add(episodeComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEpisodeComment", new { id = episodeComment.EpisodeCommentId }, episodeComment);
        }

        // DELETE: api/EpisodeComments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEpisodeComment(int id)
        {
            var episodeComment = await _context.EpisodeComment.FindAsync(id);
            if (episodeComment == null)
            {
                return NotFound();
            }

            _context.EpisodeComment.Remove(episodeComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EpisodeCommentExists(int id)
        {
            return _context.EpisodeComment.Any(e => e.EpisodeCommentId == id);
        }
    }
}
