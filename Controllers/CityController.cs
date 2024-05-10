using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PromiedosApi.Models;

namespace PromiedosApi.Controllers
{
    [Route("City")]
    public class CityController : ControllerBase
    {
        private readonly PromiedosContext _context;

        public CityController(PromiedosContext context)
        {
            _context = context;
        }

        // GET: City
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> Index()
        {
            return await _context.Cities.ToListAsync();
        }

        // GET: City/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Cities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        // POST: City/Create
        [HttpPost]
        public async Task<ActionResult<City>> PostCity([Bind("Id,CityName,Province")] City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return city;
        }

        // PUT: City/5
        [HttpPut("{id}")]
        public async Task<ActionResult<City>> UpdateCity(long id, [Bind("Id,CityName,Province")] City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return city;
        }

        // DELETE: City/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<City>> DeleteConfirmed(long id)
        {
            var city = await _context.Cities.FindAsync(id);
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CityExists(long id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
    
}


