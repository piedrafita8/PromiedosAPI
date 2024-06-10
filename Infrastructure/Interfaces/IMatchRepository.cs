using PromiedosApi.Domain.Models;

namespace PromiedosApi.Infrastructure.Interfaces
{
    public interface IMatchRepository : IGenericRepository<Match>
    {
        Task<IEnumerable<Match>> GetAllWithDetailsAsync();
        Task<Match?> GetByIdWithDetailsAsync(long id);
    }
}