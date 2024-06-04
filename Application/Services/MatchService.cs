using PromiedosApi.Application.Dtos;
using PromiedosApi.Application.Interfaces;
using PromiedosApi.Infrastructure.Interfaces;
using PromiedosApi.Domain.Models;

namespace PromiedosApi.Application.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ITournamentRepository _tournamentRepository;

        public MatchService(IMatchRepository matchRepository, ITeamRepository teamRepository, ITournamentRepository tournamentRepository)
        {
            _matchRepository = matchRepository;
            _teamRepository = teamRepository;
            _tournamentRepository = tournamentRepository;
        }

        public async Task<IEnumerable<MatchDto>> GetMatchesAsync()
        {
            var matches = await _matchRepository.GetAllAsync();
            return matches.Select(m => new MatchDto
            {
                HomeTeamId = m.HomeTeam.Id,
                AwayTeamId = m.AwayTeam.Id,
                HomeGoals = m.HomeGoals,
                AwayGoals = m.AwayGoals,
                TournamentId = m.Tournament.Id
            }).ToList();
        }

        public async Task<MatchDto> GetMatchByIdAsync(long id)
        {
            var match = await _matchRepository.GetByIdAsync(id);
            if (match == null)
            {
                return null;
            }

            return new MatchDto
            {
                HomeTeamId = match.HomeTeam.Id,
                AwayTeamId = match.AwayTeam.Id,
                HomeGoals = match.HomeGoals,
                AwayGoals = match.AwayGoals,
                TournamentId = match.Tournament.Id
            };
        }

        public async Task<MatchDto> CreateMatchAsync(MatchDto matchDto)
        {
            var homeTeam = await _teamRepository.GetByIdAsync(matchDto.HomeTeamId);
            var awayTeam = await _teamRepository.GetByIdAsync(matchDto.AwayTeamId);
            var tournament = await _tournamentRepository.GetByIdAsync(matchDto.TournamentId);

            if (homeTeam == null || awayTeam == null || tournament == null)
            {
                return null;
            }

            var match = new Match
            {
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
                HomeGoals = matchDto.HomeGoals,
                AwayGoals = matchDto.AwayGoals,
                Tournament = tournament
            };

            await _matchRepository.AddAsync(match);

            return new MatchDto
            {
                HomeTeamId = match.HomeTeam.Id,
                AwayTeamId = match.AwayTeam.Id,
                HomeGoals = match.HomeGoals,
                AwayGoals = match.AwayGoals,
                TournamentId = match.Tournament.Id
            };
        }

        public async Task UpdateMatchAsync(MatchDto matchDto)
        {
            var match = await _matchRepository.GetByIdAsync(matchDto.HomeTeamId); // Aquí parece que debería ser un id, no HomeTeamId
            if (match == null)
            {
                return;
            }

            match.HomeGoals = matchDto.HomeGoals;
            match.AwayGoals = matchDto.AwayGoals;
            match.HomeTeam = await _teamRepository.GetByIdAsync(matchDto.HomeTeamId);
            match.AwayTeam = await _teamRepository.GetByIdAsync(matchDto.AwayTeamId);
            match.Tournament = await _tournamentRepository.GetByIdAsync(matchDto.TournamentId);

            await _matchRepository.UpdateAsync(match);
        }

        public async Task DeleteMatchAsync(long id)
        {
            await _matchRepository.DeleteAsync(id);
        }
    }
}
