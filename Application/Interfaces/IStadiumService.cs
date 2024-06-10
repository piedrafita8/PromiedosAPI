using PromiedosApi.Domain.Models;
using PromiedosApi.Application.Dtos;

namespace PromiedosApi.Application.Interfaces
{
    public interface IStadiumService
    {
        Task<IEnumerable<Stadium>> GetStadiumsAsync();
        Task<StadiumDto> GetStadiumByIdAsync(long id);
        Task<StadiumDto> CreateStadiumAsync(StadiumDto stadiumDto);
        Task UpdateStadiumAsync(StadiumDto stadiumDto);
        Task DeleteStadiumAsync(long id);
    }
}