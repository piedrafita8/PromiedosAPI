using Microsoft.EntityFrameworkCore;
using PromiedosApi.Domain.Models;
using PromiedosApi.Domain.Interfaces;
using PromiedosApi.Infrastructure.Context;
using PromiedosApi.Infrastructure.Exceptions;

namespace PromiedosApi.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly PromiedosContext _context;

        public CityRepository(PromiedosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            try
            {
                return await _context.Cities.ToListAsync();
            }
            catch(Exception e)
            {
                throw new PromiedosApiException(e.Message);
            }
            
        }

        public async Task<City> GetByIdAsync(long id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public async Task AddAsync(City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(City city)
        {
            _context.Cities.Update(city);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var city = await _context.Cities.FindAsync(id);
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }
    }
}