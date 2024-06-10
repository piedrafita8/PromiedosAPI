using Microsoft.EntityFrameworkCore;
using PromiedosApi.Domain.Models;
using PromiedosApi.Infrastructure.Context;
using PromiedosApi.Infrastructure.Exceptions;
using PromiedosApi.Infrastructure.Interfaces;

namespace PromiedosApi.Infrastructure.Repositories
{
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        private readonly PromiedosContext _context;

        public MatchRepository(PromiedosContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Match>> GetAllWithDetailsAsync()
        {
            try
            {
                return await _context.Matches
                    .Include(m => m.HomeTeam)
                    .Include(m => m.AwayTeam)
                    .Include(m => m.Tournament)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new PromiedosApiException(e.Message);
            }
        }

        public async Task<Match?> GetByIdWithDetailsAsync(long id)
        {
            try
            {
                return await _context.Matches
                    .Include(m => m.HomeTeam)
                    .Include(m => m.AwayTeam)
                    .Include(m => m.Tournament)
                    .FirstOrDefaultAsync(m => m.Id == id);
            }
            catch (Exception e)
            {
                throw new PromiedosApiException(e.Message);
            }
        }
    }
}