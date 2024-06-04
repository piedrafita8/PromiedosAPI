using PromiedosApi.Domain.Models;

namespace PromiedosApi.Infrastructure.Interfaces
{
    public interface IStadiumRepository
    {
        Task<IEnumerable<Stadium>> GetAllAsync();
        Task<Stadium> GetByIdAsync(long id);
        Task AddAsync(Stadium stadium);
        Task UpdateAsync(Stadium stadium);
        Task DeleteAsync(long id);
    }
}