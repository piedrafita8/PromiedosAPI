using Microsoft.AspNetCore.Mvc;
using PromiedosApi.Application.Dtos;
using PromiedosApi.Application.Interfaces;

namespace PromiedosApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        // GET: api/Match
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchDto>>> GetMatches()
        {
            var matches = await _matchService.GetMatchesAsync();
            return Ok(matches);
        }

        // GET: api/Match/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchDto>> GetMatch(long id)
        {
            var match = await _matchService.GetMatchByIdAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            return Ok(match);
        }

        // POST: api/Match
        [HttpPost]
        public async Task<ActionResult<MatchDto>> PostMatch([FromBody] MatchDto matchDto)
        {
            var newMatch = await _matchService.CreateMatchAsync(matchDto);
            if (newMatch == null)
            {
                return BadRequest("Equipos o torneo especificados no existen.");
            }
            return CreatedAtAction(nameof(GetMatch), new { id = newMatch.HomeTeamId }, newMatch);
        }

        // PUT: api/Match/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch(long id, [FromBody] MatchDto matchDto)
        {
            if (id != matchDto.HomeTeamId) // Este debería ser el id del match, no HomeTeamId
            {
                return BadRequest();
            }

            await _matchService.UpdateMatchAsync(matchDto);
            return NoContent();
        }

        // DELETE: api/Match/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(long id)
        {
            await _matchService.DeleteMatchAsync(id);
            return NoContent();
        }
    }
}
