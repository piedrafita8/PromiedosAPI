using PromiedosApi.Application.Dtos;
using PromiedosApi.Application.Interfaces;
using PromiedosApi.Domain.Models;
using PromiedosApi.Infrastructure.Interfaces;

namespace PromiedosApi.Application.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<CityDto>> GetCitiesAsync()
        {
            var cities = await _cityRepository.GetAllAsync();
            return cities.Select(c => new CityDto { Id = c.Id, CityName = c.CityName, Province = c.Province }).ToList();
        }

        public async Task<CityDto> GetCityByIdAsync(long id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            if (city == null)
            {
                return null;
            }

            return new CityDto { Id = city.Id, CityName = city.CityName, Province = city.Province };
        }

        public async Task<CityDto> CreateCityAsync(CityDto cityDto)
        {
            var city = new City { CityName = cityDto.CityName, Province = cityDto.Province };
            await _cityRepository.AddAsync(city);
            return new CityDto { Id = city.Id, CityName = city.CityName, Province = city.Province };
        }

        public async Task UpdateCityAsync(CityDto cityDto)
        {
            var city = new City { Id = cityDto.Id, CityName = cityDto.CityName, Province = cityDto.Province };
            await _cityRepository.UpdateAsync(city);
        }

        public async Task DeleteCityAsync(long id)
        {
            await _cityRepository.DeleteAsync(id);
        }
    }
}