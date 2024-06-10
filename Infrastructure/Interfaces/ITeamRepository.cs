using PromiedosApi.Domain.Models;

namespace PromiedosApi.Infrastructure.Interfaces
{
    public interface ITeamRepository : IGenericRepository<Team>
    {
        Task<IEnumerable<Team>> GetAllWithDetailsAsync();
        Task<Team?> GetByIdWithDetailsAsync(long id);
    }
}