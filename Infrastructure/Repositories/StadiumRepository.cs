using PromiedosApi.Infrastructure.Interfaces;
using PromiedosApi.Domain.Models;
using PromiedosApi.Infrastructure.Context;

namespace PromiedosApi.Infrastructure.Repositories
{
    public class StadiumRepository : GenericRepository<Stadium>, IStadiumRepository
    {
        public StadiumRepository(PromiedosContext context) : base(context)
        {
        }

        
    }
}