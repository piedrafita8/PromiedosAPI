using PromiedosApi.Application.Dtos;

namespace PromiedosApi.Application.Interfaces
{
    public interface IMatchService
    {
        Task<IEnumerable<MatchDto>> GetMatchesAsync();
        Task<MatchDto> GetMatchByIdAsync(long id);
        Task<MatchDto> CreateMatchAsync(MatchDto matchDto);
        Task UpdateMatchAsync(MatchDto matchDto);
        Task DeleteMatchAsync(long id);
    }
}