using Microsoft.AspNetCore.Mvc;
using PromiedosApi.Application.Dtos;
using PromiedosApi.Application.Interfaces;

namespace PromiedosApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        // GET: api/Tournament
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentDto>>> GetTournaments()
        {
            var tournaments = await _tournamentService.GetTournamentsAsync();
            return Ok(tournaments);
        }

        // GET: api/Tournament/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentDto>> GetTournament(long id)
        {
            var tournament = await _tournamentService.GetTournamentByIdAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }
            return Ok(tournament);
        }

        // POST: api/Tournament
        [HttpPost]
        public async Task<ActionResult<TournamentDto>> PostTournament([FromBody] TournamentDto dto)
        {
            var newTournament = await _tournamentService.CreateTournamentAsync(dto);
            return CreatedAtAction(nameof(GetTournament), new { id = newTournament.Id }, newTournament);
        }

        // PUT: api/Tournament/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournament(long id, [FromBody] TournamentDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            await _tournamentService.UpdateTournamentAsync(dto);
            return NoContent();
        }

        // DELETE: api/Tournament/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(long id)
        {
            await _tournamentService.DeleteTournamentAsync(id);
            return NoContent();
        }

        // PUT: api/Tournament/AddTeam/5
        [HttpPut("{id}/AddTeam/{teamId}")]
        public async Task<IActionResult> AddTeamToTournament(long id, long teamId)
        {
            await _tournamentService.AddTeamToTournamentAsync(id, teamId);
            return NoContent();
        }

        // DELETE: api/Tournament/RemoveTeam/5
        [HttpDelete("{id}/RemoveTeam/{teamId}")]
        public async Task<IActionResult> RemoveTeamFromTournament(long id, long teamId)
        {
            await _tournamentService.RemoveTeamFromTournamentAsync(id, teamId);
            return NoContent();
        }
    }
}
