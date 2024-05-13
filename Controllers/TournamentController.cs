using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PromiedosApi.Models;

namespace PromiedosApi.Controllers
{
    [Route("Tournament")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly PromiedosContext _context;

        public TournamentController(PromiedosContext context)
        {
            _context = context;
        }

        // GET: Tournament
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournaments()
        {
            return await _context.Tournaments.ToListAsync();
        }

        // GET: Tournament/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetTournament(long id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return tournament;
        }

        // PUT: Tournament/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Tournament>> PutTournament(long id, Tournament tournament)
        {
            if (id != tournament.Id)
            {
                return BadRequest();
            }

            _context.Entry(tournament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentExists(id))
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

        // POST: Tournament
        [HttpPost]
        public async Task<ActionResult<Tournament>> PostTournament(string tournamentName, string format, int year)
        {
            var tournamentsCount = await _context.Tournaments.CountAsync();
            var tournament = new Tournament
            {
                TournamentName = tournamentName,
                Id = tournamentsCount + 1,
                Format = format,
                Year = year,
                Teams = new List<Team>()
            };
            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTournament), new { id = tournament.Id }, tournament);
        }

        // DELETE: Tournament/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tournament>> DeleteTournament(long id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();

            return tournament;
        }

        // PUT: Tournament/AddTeam/5
        [HttpPut("AddTeam/{id}")]
        public async Task<IActionResult> AddTeamToTournament(long id, long teamId)
        {
            var tournament = await _context.Tournaments.Include(t => t.Teams).FirstOrDefaultAsync(t => t.Id == id);
            if (tournament == null)
            {
                return NotFound("Tournament not found.");
            }

            var team = await _context.Teams.FindAsync(teamId);
            if (team == null)
            {
                return NotFound("Team not found.");
            }

            if (tournament.Teams.Any(t => t.Id == teamId))
            {
                return BadRequest("Team already added to the tournament.");
            }

            tournament.Teams.Add(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: Tournament/RemoveTeam/5
        [HttpDelete("RemoveTeam/{id}")]
        public async Task<IActionResult> RemoveTeamFromTournament(long id, long teamId)
        {
            var tournament = await _context.Tournaments.Include(t => t.Teams).FirstOrDefaultAsync(t => t.Id == id);
            if (tournament == null)
            {
                return NotFound("Tournament not found.");
            }

            var team = tournament.Teams.FirstOrDefault(t => t.Id == teamId);
            if (team == null)
            {
                return NotFound("Team not found in the tournament.");
            }

            tournament.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TournamentExists(long id)
        {
            return _context.Tournaments.Any(e => e.Id == id);
        }
    }
}
