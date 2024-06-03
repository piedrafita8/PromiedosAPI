using Microsoft.EntityFrameworkCore;
using PromiedosApi.Domain.Models;

namespace PromiedosApi.Infrastructure.Context;

public class PromiedosContext : DbContext
{
    public PromiedosContext(DbContextOptions<PromiedosContext> options) 
        : base(options)
    {
        
    }

    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Match> Matches { get; set; } = null!;
    public DbSet<Stadium> Stadiums { get; set; } = null!;
    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<Tournament> Tournaments { get; set; } = null!;


}