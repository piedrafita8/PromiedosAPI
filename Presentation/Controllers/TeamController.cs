using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PromiedosApi.Domain.Models;
using PromiedosApi.Infrastructure.Context;
using PromiedosApi.Application.Dtos;

namespace PromiedosApi.Controllers
{
    [Route("Team")]
    public class TeamController : ControllerBase
    {
        private readonly PromiedosContext _context;

        public TeamController(PromiedosContext context)
        {
            _context = context;
        }

        // GET: Team
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            return await _context.Teams.ToListAsync();
        }

        // GET: Team/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(long id)
        {
            var team = await _context.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        // PUT: Team/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Team>> PutTeam(long id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: Team
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam([FromBody] TeamDto teamDto)
        {
            
            var existingCity = await _context.Cities.FindAsync(teamDto.CityId);
            var existingStadium = await _context.Stadiums.FindAsync(teamDto.StadiumId);

            if (existingCity == null )
            {
                return BadRequest("La ciudad especificada no existe.");
            }
            if ( existingStadium == null)
            {
                return BadRequest("El estadio especificado no existe.");
            }

            var teamsCount = await _context.Teams.CountAsync();

            var team = new Team
            {
                TeamName = teamDto.TeamName,
                City = existingCity,
                Stadium = existingStadium,
                Id = teamsCount + 1,
            };
                
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeam), new { id = team.Id }, team);
        }

        // DELETE: Team/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeam(long id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamExists(long id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
