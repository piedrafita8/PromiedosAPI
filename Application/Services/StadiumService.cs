using PromiedosApi.Application.Dtos;
using PromiedosApi.Application.Interfaces;
using PromiedosApi.Infrastructure.Interfaces;
using PromiedosApi.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Stadium>> GetStadiumsAsync()
        {
            var stadiums = await _stadiumRepository.GetAllAsync();
            return stadiums;
        }

        public async Task<StadiumDto> GetStadiumByIdAsync(long id)
        {
            var stadium = await _stadiumRepository.GetByIdAsync(id);
            if (stadium == null)
            {
                return null;
            }

            return new StadiumDto 
            { 
                Id = stadium.Id, 
                StadiumName = stadium.StadiumName, 
                CityId = stadium.City.Id,
            };
        }

        public async Task<StadiumDto> CreateStadiumAsync(StadiumDto stadiumDto)
        {
            var existingCity = await _cityRepository.GetByIdAsync(stadiumDto.CityId);
            if (existingCity == null)
            {
                throw new KeyNotFoundException("La ciudad especificada no existe.");
            }

            var stadium = new Stadium
            {
                Id = stadiumDto.Id,
                StadiumName = stadiumDto.StadiumName,
                City = existingCity
            };

            await _stadiumRepository.AddAsync(stadium);
            return new StadiumDto 
            { 
                Id = stadium.Id, 
                StadiumName = stadium.StadiumName, 
                CityId = stadium.City.Id
            };
        }

        public async Task UpdateStadiumAsync(StadiumDto stadiumDto)
        {
            var existingCity = await _cityRepository.GetByIdAsync(stadiumDto.CityId);
            if (existingCity == null)
            {
                throw new KeyNotFoundException("La ciudad especificada no existe.");
            }

            var stadium = new Stadium
            {
                Id = stadiumDto.Id,
                StadiumName = stadiumDto.StadiumName,
                City = existingCity
            };

            await _stadiumRepository.UpdateAsync(stadium);
        }

        public async Task DeleteStadiumAsync(long id)
        {
            await _stadiumRepository.DeleteAsync(id);
        }
    }
}
