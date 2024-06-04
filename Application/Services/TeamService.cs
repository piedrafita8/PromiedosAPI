using PromiedosApi.Application.Dtos;
using PromiedosApi.Application.Interfaces;
using PromiedosApi.Domain.Models;
using PromiedosApi.Infrastructure.Interfaces;

namespace PromiedosApi.Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IStadiumRepository _stadiumRepository;

        public TeamService(ITeamRepository teamRepository, ICityRepository cityRepository, IStadiumRepository stadiumRepository)
        {
            _teamRepository = teamRepository;
            _cityRepository = cityRepository;
            _stadiumRepository = stadiumRepository;
        }

        public async Task<IEnumerable<TeamDto>> GetTeamsAsync()
        {
            var teams = await _teamRepository.GetAllAsync();
            return teams.Select(t => new TeamDto { TeamName = t.TeamName, CityId = t.City.Id, StadiumId = t.Stadium.Id }).ToList();
        }

        public async Task<TeamDto> GetTeamByIdAsync(long id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null)
            {
                return null;
            }

            return new TeamDto { TeamName = team.TeamName, CityId = team.City.Id, StadiumId = team.Stadium.Id };
        }

        public async Task<TeamDto> CreateTeamAsync(TeamDto teamDto)
        {
            var city = await _cityRepository.GetByIdAsync(teamDto.CityId);
            var stadium = await _stadiumRepository.GetByIdAsync(teamDto.StadiumId);
            if (city == null || stadium == null)
            {
                return null;
            }

            var team = new Team { TeamName = teamDto.TeamName, City = city, Stadium = stadium };
            await _teamRepository.AddAsync(team);
            return new TeamDto { TeamName = team.TeamName, CityId = team.City.Id, StadiumId = team.Stadium.Id };
        }

        public async Task UpdateTeamAsync(TeamDto teamDto)
        {
            var team = await _teamRepository.GetByIdAsync(teamDto.CityId);
            if (team == null)
            {
                return;
            }

            team.TeamName = teamDto.TeamName;
            await _teamRepository.UpdateAsync(team);
        }

        public async Task DeleteTeamAsync(long id)
        {
            await _teamRepository.DeleteAsync(id);
        }
    }
}
