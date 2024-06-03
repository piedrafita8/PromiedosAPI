using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PromiedosApi.Domain.Models;
using PromiedosApi.Infrastructure.Context;
using PromiedosApi.Application.Dtos;

namespace PromiedosApi.Controllers
{
    [Route("Match")]
    public class MatchController : ControllerBase
    {
        private readonly PromiedosContext _context;

        public MatchController(PromiedosContext context)
        {
            _context = context;
        }

        // GET: Match
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatches()
        {
            return await _context.Matches.ToListAsync();
        }

        // GET: Match/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(long id)
        {
            var match = await _context.Matches.FindAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            return match;
        }

        // PUT: Match/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Match>> PutMatch(long id, Match match)
        {
            if (id != match.Id)
            {
                return BadRequest();
            }

            _context.Entry(match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
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

        // POST: Match
        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch([FromBody] MatchDto matchDto)
        {
            var homeTeam = await _context.Teams.FindAsync(matchDto.HomeTeamId);
            var awayTeam = await _context.Teams.FindAsync(matchDto.AwayTeamId);
            var tournament = await _context.Tournaments.FindAsync(matchDto.TournamentId);

            if (homeTeam == null || awayTeam == null || tournament == null)
            {
                return BadRequest("Equipos o torneo especificados no existen.");
            }

            var match = new Match
            {
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
                HomeGoals = matchDto.HomeGoals,
                AwayGoals = matchDto.AwayGoals,
                Tournament = tournament
            };

            _context.Matches.Add(match);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMatch), new { id = match.Id }, match);
        }


        // DELETE: Match/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMatch(long id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatchExists(long id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }
    }
}
