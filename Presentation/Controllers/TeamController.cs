using Microsoft.AspNetCore.Mvc;
using PromiedosApi.Application.Dtos;
using PromiedosApi.Application.Interfaces;

namespace PromiedosApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        // GET: api/Team
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeams()
        {
            var teams = await _teamService.GetTeamsAsync();
            return Ok(teams);
        }

        // GET: api/Team/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDto>> GetTeam(long id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        // POST: api/Team
        [HttpPost]
        public async Task<ActionResult<TeamDto>> PostTeam([FromBody] TeamDto teamDto)
        {
            var newTeam = await _teamService.CreateTeamAsync(teamDto);
            if (newTeam == null)
            {
                return BadRequest("City or Stadium does not exist.");
            }
            return CreatedAtAction(nameof(GetTeam), new { id = newTeam.CityId }, newTeam);
        }

        // PUT: api/Team/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(long id, [FromBody] TeamDto teamDto)
        {
            if (id != teamDto.CityId)
            {
                return BadRequest();
            }

            await _teamService.UpdateTeamAsync(teamDto);
            return NoContent();
        }

        // DELETE: api/Team/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(long id)
        {
            await _teamService.DeleteTeamAsync(id);
            return NoContent();
        }
    }
}
