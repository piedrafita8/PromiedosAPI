using PromiedosApi.Application.Dtos;
using PromiedosApi.Application.Interfaces;
using PromiedosApi.Infrastructure.Interfaces;
using PromiedosApi.Domain.Models;

namespace PromiedosApi.Application.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITeamRepository _teamRepository;

        public TournamentService(ITournamentRepository tournamentRepository, ITeamRepository teamRepository)
        {
            _tournamentRepository = tournamentRepository;
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<TournamentDto>> GetTournamentsAsync()
        {
            var tournaments = await _tournamentRepository.GetAllAsync();
            return tournaments.Select(t => new TournamentDto
            {
                TournamentName = t.TournamentName,
                Format = t.Format,
                Year = t.Year
            }).ToList();
        }

        public async Task<TournamentDto> GetTournamentByIdAsync(long id)
        {
            var tournament = await _tournamentRepository.GetByIdAsync(id);
            if (tournament == null)
            {
                return null;
            }

            return new TournamentDto
            {
                TournamentName = tournament.TournamentName,
                Format = tournament.Format,
                Year = tournament.Year
            };
        }

        public async Task<TournamentDto> CreateTournamentAsync(TournamentDto tournamentDto)
        {
            var tournament = new Tournament
            {
                TournamentName = tournamentDto.TournamentName,
                Format = tournamentDto.Format,
                Year = tournamentDto.Year
            };

            await _tournamentRepository.AddAsync(tournament);

            return tournamentDto;
        }

        public async Task UpdateTournamentAsync(TournamentDto tournamentDto)
        {
            var tournament = await _tournamentRepository.GetByIdAsync(tournamentDto.Id);
            if (tournament == null)
            {
                return;
            }

            tournament.TournamentName = tournamentDto.TournamentName;
            tournament.Format = tournamentDto.Format;
            tournament.Year = tournamentDto.Year;

            await _tournamentRepository.UpdateAsync(tournament);
        }

        public async Task DeleteTournamentAsync(long id)
        {
            await _tournamentRepository.DeleteAsync(id);
        }

        public async Task AddTeamToTournamentAsync(long tournamentId, long teamId)
        {
            var tournament = await _tournamentRepository.GetByIdAsync(tournamentId);
            if (tournament == null)
            {
                return;
            }

            var team = await _teamRepository.GetByIdAsync(teamId);
            if (team == null)
            {
                return;
            }

            if (tournament.Teams == null)
            {
                tournament.Teams = new List<Team>();
            }

            if (!tournament.Teams.Any(t => t.Id == teamId))
            {
                tournament.Teams.Add(team);
                await _tournamentRepository.UpdateAsync(tournament);
            }
        }

        public async Task RemoveTeamFromTournamentAsync(long tournamentId, long teamId)
        {
            var tournament = await _tournamentRepository.GetByIdAsync(tournamentId);
            if (tournament == null)
            {
                return;
            }

            var team = tournament.Teams.FirstOrDefault(t => t.Id == teamId);
            if (team != null)
            {
                tournament.Teams.Remove(team);
                await _tournamentRepository.UpdateAsync(tournament);
            }
        }
    }
}
