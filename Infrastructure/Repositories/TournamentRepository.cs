using Microsoft.EntityFrameworkCore;
using PromiedosApi.Infrastructure.Interfaces;
using PromiedosApi.Domain.Models;
using PromiedosApi.Infrastructure.Context;

namespace PromiedosApi.Infrastructure.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly PromiedosContext _context;

        public TournamentRepository(PromiedosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tournament>> GetAllAsync()
        {
            return await _context.Tournaments.Include(t => t.Teams).ToListAsync();
        }

        public async Task<Tournament> GetByIdAsync(long id)
        {
            return await _context.Tournaments.Include(t => t.Teams).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Tournament tournament)
        {
            await _context.Tournaments.AddAsync(tournament);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tournament tournament)
        {
            _context.Tournaments.Update(tournament);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament != null)
            {
                _context.Tournaments.Remove(tournament);
                await _context.SaveChangesAsync();
            }
        }
    }
}