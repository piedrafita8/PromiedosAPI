using Microsoft.EntityFrameworkCore;
using PromiedosApi.Infrastructure.Interfaces;
using PromiedosApi.Domain.Models;
using PromiedosApi.Infrastructure.Context;

namespace PromiedosApi.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly PromiedosContext _context;

        public TeamRepository(PromiedosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _context.Teams.Include(t => t.City).Include(t => t.Stadium).ToListAsync();
        }

        public async Task<Team> GetByIdAsync(long id)
        {
            return await _context.Teams.Include(t => t.City).Include(t => t.Stadium).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Team team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
            }
        }
    }
}