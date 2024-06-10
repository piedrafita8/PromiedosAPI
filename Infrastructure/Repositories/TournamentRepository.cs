
using PromiedosApi.Domain.Models;
using PromiedosApi.Infrastructure.Context;
using PromiedosApi.Infrastructure.Interfaces;


namespace PromiedosApi.Infrastructure.Repositories
{
    public class TournamentRepository : GenericRepository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(PromiedosContext context) : base(context)
        {
        }


    }
}