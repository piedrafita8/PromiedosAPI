using PromiedosApi.Application.Dtos;

namespace PromiedosApi.Application.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetCitiesAsync();
        Task<CityDto> GetCityByIdAsync(long id);
        Task<CityDto> CreateCityAsync(CityDto cityDto);
        Task UpdateCityAsync(CityDto cityDto);
        Task DeleteCityAsync(long id);
    }
}