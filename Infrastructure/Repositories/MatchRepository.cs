using Microsoft.EntityFrameworkCore;
using PromiedosApi.Infrastructure.Interfaces;
using PromiedosApi.Domain.Models;
using PromiedosApi.Infrastructure.Context;

namespace PromiedosApi.Infrastructure.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly PromiedosContext _context;

        public MatchRepository(PromiedosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Match>> GetAllAsync()
        {
            return await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.Tournament)
                .ToListAsync();
        }

        public async Task<Match> GetByIdAsync(long id)
        {
            return await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.Tournament)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(Match match)
        {
            await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Match match)
        {
            _context.Matches.Update(match);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var match = await _context.Matches.FindAsync(id);
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
        }
    }
}