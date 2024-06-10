using Microsoft.EntityFrameworkCore;
using PromiedosApi.Domain.Models;
using PromiedosApi.Infrastructure.Context;
using PromiedosApi.Infrastructure.Exceptions;
using PromiedosApi.Infrastructure.Interfaces;

namespace PromiedosApi.Infrastructure.Repositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        private readonly PromiedosContext _context;

        public TeamRepository(PromiedosContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAllWithDetailsAsync()
        {
            try
            {
                return await _context.Teams
                    .Include(t => t.City)
                    .Include(t => t.Stadium)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new PromiedosApiException(e.Message);
            }
        }

        public async Task<Team?> GetByIdWithDetailsAsync(long id)
        {
            try
            {
                return await _context.Teams
                    .Include(t => t.City)
                    .Include(t => t.Stadium)
                    .FirstOrDefaultAsync(t => t.Id == id);
            }
            catch (Exception e)
            {
                throw new PromiedosApiException(e.Message);
            }
        }
    }
}