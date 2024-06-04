using PromiedosApi.Application.Dtos;

namespace PromiedosApi.Application.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDto>> GetTeamsAsync();
        Task<TeamDto> GetTeamByIdAsync(long id);
        Task<TeamDto> CreateTeamAsync(TeamDto teamDto);
        Task UpdateTeamAsync(TeamDto teamDto);
        Task DeleteTeamAsync(long id);
    }
}