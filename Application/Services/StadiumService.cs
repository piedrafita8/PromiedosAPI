using PromiedosApi.Application.Dtos;
using PromiedosApi.Application.Interfaces;
using PromiedosApi.Domain.Models;
using PromiedosApi.Infrastructure.Interfaces;


namespace PromiedosApi.Application.Services
{
    public class StadiumService : IStadiumService
    {
        private readonly IStadiumRepository _stadiumRepository;
        private readonly ICityRepository _cityRepository;

        public StadiumService(IStadiumRepository stadiumRepository, ICityRepository cityRepository)
        {
            _stadiumRepository = stadiumRepository;
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<StadiumDto>> GetStadiumsAsync()
        {
            var stadiums = await _stadiumRepository.GetAllAsync();
            return stadiums.Select(s => new StadiumDto { StadiumName = s.StadiumName, CityId = s.City.Id }).ToList();
        }

        public async Task<StadiumDto> GetStadiumByIdAsync(long id)
        {
            var stadium = await _stadiumRepository.GetByIdAsync(id);
            if (stadium == null)
            {
                return null;
            }

            return new StadiumDto { StadiumName = stadium.StadiumName, CityId = stadium.City.Id };
        }

        public async Task<StadiumDto> CreateStadiumAsync(StadiumDto stadiumDto)
        {
            var city = await _cityRepository.GetByIdAsync(stadiumDto.CityId);
            if (city == null)
            {
                return null;
            }

            var stadium = new Stadium { StadiumName = stadiumDto.StadiumName, City = city };
            await _stadiumRepository.AddAsync(stadium);
            return new StadiumDto { StadiumName = stadium.StadiumName, CityId = stadium.City.Id };
        }

        public async Task UpdateStadiumAsync(StadiumDto stadiumDto)
        {
            var stadium = await _stadiumRepository.GetByIdAsync(stadiumDto.CityId);
            if (stadium == null)
            {
                return;
            }

            stadium.StadiumName = stadiumDto.StadiumName;
            await _stadiumRepository.UpdateAsync(stadium);
        }

        public async Task DeleteStadiumAsync(long id)
        {
            await _stadiumRepository.DeleteAsync(id);
        }
    }
}
