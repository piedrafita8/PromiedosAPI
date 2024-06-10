using PromiedosApi.Infrastructure.Interfaces;
using PromiedosApi.Domain.Models;
using PromiedosApi.Infrastructure.Context;

namespace PromiedosApi.Infrastructure.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(PromiedosContext context) : base(context)
        {
        }

        
    }
}