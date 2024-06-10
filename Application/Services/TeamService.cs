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
            var teams = await _teamRepository.GetAllWithDetailsAsync();
            return teams.Select(t => new TeamDto
            {
                Id = t.Id,
                TeamName = t.TeamName,
                CityId = t.City.Id,
                StadiumId = t.Stadium.Id
            }).ToList();
        }

        public async Task<TeamDto?> GetTeamByIdAsync(long id)
        {
            var team = await _teamRepository.GetByIdWithDetailsAsync(id);
            if (team == null)
            {
                return null;
            }

            return new TeamDto
            {
                Id = team.Id,
                TeamName = team.TeamName,
                CityId = team.City.Id,
                StadiumId = team.Stadium.Id
            };
        }

        public async Task<TeamDto> CreateTeamAsync(TeamDto teamDto)
        {
            var city = await _cityRepository.GetByIdAsync(teamDto.CityId);
            var stadium = await _stadiumRepository.GetByIdAsync(teamDto.StadiumId);

            if (city == null || stadium == null)
            {
                throw new Exception("City or Stadium specified does not exist.");
            }

            var team = new Team
            {
                Id = teamDto.Id,
                TeamName = teamDto.TeamName,
                City = city,
                Stadium = stadium
            };

            await _teamRepository.AddAsync(team);

            return new TeamDto
            {
                Id = team.Id,
                TeamName = team.TeamName,
                CityId = team.City.Id,
                StadiumId = team.Stadium.Id
            };
        }

        public async Task UpdateTeamAsync(TeamDto teamDto)
        {
            var team = await _teamRepository.GetByIdAsync(teamDto.Id);
            if (team == null)
            {
                throw new Exception("Team not found");
            }

            var city = await _cityRepository.GetByIdAsync(teamDto.CityId);
            var stadium = await _stadiumRepository.GetByIdAsync(teamDto.StadiumId);

            if (city == null || stadium == null)
            {
                throw new Exception("City or Stadium specified does not exist.");
            }

            team.TeamName = teamDto.TeamName;
            team.City = city;
            team.Stadium = stadium;

            await _teamRepository.UpdateAsync(team);
        }

        public async Task DeleteTeamAsync(long id)
        {
            await _teamRepository.DeleteAsync(id);
        }
    }
}
