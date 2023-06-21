// Ignore Spelling: Kob

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NB.KingOfBeers.Database.Models;

namespace NB.KingOfBeers.Database.Context;

public class KobDataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public KobDataContext()
    {

    }

    public KobDataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    /// <summary>
    /// Configure DB Context.
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(Configuration.GetConnectionString("sql_connection"));
    }

    public virtual DbSet<Beer> Beer { get; set; }
    public DbSet<Bar> Bar { get; set; }
    public DbSet<Brewery> Brewery { get; set; }
    public DbSet<BreweryBeers> BreweryBeer { get; set; }
    public DbSet<BarBeers> BarBeer { get; set; }
}