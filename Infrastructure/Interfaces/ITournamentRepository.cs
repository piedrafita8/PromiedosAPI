using PromiedosApi.Domain.Models;

namespace PromiedosApi.Infrastructure.Interfaces
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<Tournament>> GetAllAsync();
        Task<Tournament> GetByIdAsync(long id);
        Task AddAsync(Tournament tournament);
        Task UpdateAsync(Tournament tournament);
        Task DeleteAsync(long id);
    }
}