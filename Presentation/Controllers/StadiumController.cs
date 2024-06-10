using Microsoft.AspNetCore.Mvc;
using PromiedosApi.Application.Dtos;
using PromiedosApi.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromiedosApi.Controllers
{
    [Route("Stadium")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly IStadiumService _stadiumService;

        public StadiumController(IStadiumService stadiumService)
        {
            _stadiumService = stadiumService;
        }

        // GET: Stadium
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StadiumDto>>> GetStadiums()
        {
            var stadiums = await _stadiumService.GetStadiumsAsync();
            return Ok(stadiums);
        }

        // GET: Stadium/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StadiumDto>> GetStadium(long id)
        {
            var stadium = await _stadiumService.GetStadiumByIdAsync(id);
            if (stadium == null)
            {
                return NotFound();
            }

            return Ok(stadium);
        }

        // POST: Stadium
        [HttpPost]
        public async Task<ActionResult<StadiumDto>> PostStadium([FromBody] StadiumDto stadiumDto)
        {
            try
            {
                var createdStadium = await _stadiumService.CreateStadiumAsync(stadiumDto);
                return CreatedAtAction(nameof(GetStadium), new { id = createdStadium.Id }, createdStadium);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: Stadium/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStadium(long id, [FromBody] StadiumDto stadiumDto)
        {
            if (id != stadiumDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _stadiumService.UpdateStadiumAsync(stadiumDto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: Stadium/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStadium(long id)
        {
            await _stadiumService.DeleteStadiumAsync(id);
            return NoContent();
        }
    }
}
