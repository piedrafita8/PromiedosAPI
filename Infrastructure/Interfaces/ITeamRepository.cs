using PromiedosApi.Domain.Models;

namespace PromiedosApi.Infrastructure.Interfaces
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team> GetByIdAsync(long id);
        Task AddAsync(Team team);
        Task UpdateAsync(Team team);
        Task DeleteAsync(long id);
    }
}