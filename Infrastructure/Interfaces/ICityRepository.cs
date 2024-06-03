using PromiedosApi.Domain.Models;

namespace PromiedosApi.Domain.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllAsync();
        Task<City?> GetByIdAsync(long id);
        Task AddAsync(City city);
        Task UpdateAsync(City city);
        Task DeleteAsync(long id);
    }
}