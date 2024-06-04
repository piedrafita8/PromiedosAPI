using Microsoft.EntityFrameworkCore;
using PromiedosApi.Infrastructure.Interfaces;
using PromiedosApi.Domain.Models;
using PromiedosApi.Infrastructure.Context;

namespace PromiedosApi.Infrastructure.Repositories
{
    public class StadiumRepository : IStadiumRepository
    {
        private readonly PromiedosContext _context;

        public StadiumRepository(PromiedosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stadium>> GetAllAsync()
        {
            return await _context.Stadiums.Include(s => s.City).ToListAsync();
        }

        public async Task<Stadium> GetByIdAsync(long id)
        {
            return await _context.Stadiums.Include(s => s.City).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Stadium stadium)
        {
            await _context.Stadiums.AddAsync(stadium);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Stadium stadium)
        {
            _context.Stadiums.Update(stadium);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var stadium = await _context.Stadiums.FindAsync(id);
            if (stadium != null)
            {
                _context.Stadiums.Remove(stadium);
                await _context.SaveChangesAsync();
            }
        }
    }
}