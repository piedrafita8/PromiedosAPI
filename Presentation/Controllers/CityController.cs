using Microsoft.AspNetCore.Mvc;
using PromiedosApi.Application.Interfaces;
using PromiedosApi.Application.Dtos;

namespace PromiedosApi.Presentation.Controllers
{
    [Route("City")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities()
        {
            return Ok(await _cityService.GetCitiesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetCity(long id)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult<CityDto>> PostCity([FromBody] CityDto cityDto)
        {
            var city = await _cityService.CreateCityAsync(cityDto);
            return CreatedAtAction(nameof(GetCity), new { id = city.Id }, city);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(long id, [FromBody] CityDto cityDto)
        {
            if (id != cityDto.Id)
            {
                return BadRequest();
            }

            await _cityService.UpdateCityAsync(cityDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(long id)
        {
            await _cityService.DeleteCityAsync(id);
            return NoContent();
        }
    }
}