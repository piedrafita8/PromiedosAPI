using PromiedosApi.Application.Dtos;

namespace PromiedosApi.Application.Interfaces
{
    public interface ITournamentService
    {
        Task<IEnumerable<TournamentDto>> GetTournamentsAsync();
        Task<TournamentDto> GetTournamentByIdAsync(long id);
        Task<TournamentDto> CreateTournamentAsync(TournamentDto tournamentDto);
        Task UpdateTournamentAsync(TournamentDto tournamentDto);
        Task DeleteTournamentAsync(long id);
        Task AddTeamToTournamentAsync(long tournamentId, long teamId);
        Task RemoveTeamFromTournamentAsync(long tournamentId, long teamId);
    }
}