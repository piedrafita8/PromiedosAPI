using PromiedosApi.Domain.Models;

namespace PromiedosApi.Infrastructure.Interfaces
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Match>> GetAllAsync();
        Task<Match> GetByIdAsync(long id);
        Task AddAsync(Match match);
        Task UpdateAsync(Match match);
        Task DeleteAsync(long id);
    }
}