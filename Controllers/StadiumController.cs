using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PromiedosApi.Models;

namespace PromiedosApi.Controllers
{
    [Route("Stadium")]
    public class StadiumController : ControllerBase
    {
        private readonly PromiedosContext _context;

        public StadiumController(PromiedosContext context)
        {
            _context = context;
        }

        // GET: Stadium
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stadium>>> GetStadiums()
        {
            return await _context.Stadiums.ToListAsync();
        }

        // GET: Stadium/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stadium>> GetStadium(long id)
        {
            var stadium = await _context.Stadiums.FindAsync(id);

            if (stadium == null)
            {
                return NotFound();
            }

            return stadium;
        }

        // PUT: Stadium/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Stadium>> PutStadium(long id, Stadium stadium)
        {
            if (id != stadium.Id)
            {
                return BadRequest();
            }

            _context.Entry(stadium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StadiumExists(id))
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

        // POST: Stadium
        [HttpPost]
        public async Task<ActionResult<Stadium>> PostStadium(Stadium stadium)
        {
            _context.Stadiums.Add(stadium);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStadium), new { id = stadium.Id }, stadium);
        }

        // DELETE: Stadium/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStadium(long id)
        {
            var stadium = await _context.Stadiums.FindAsync(id);
            if (stadium == null)
            {
                return NotFound();
            }

            _context.Stadiums.Remove(stadium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StadiumExists(long id)
        {
            return _context.Stadiums.Any(e => e.Id == id);
        }
    }
}
