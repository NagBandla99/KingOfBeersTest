namespace NB.KingOfBeers.Api;

using NB.KingOfBeers.Api.Validators;
using NB.KingOfBeers.Application.Mappers;
using NB.KingOfBeers.Application.Services;
using NB.KingOfBeers.Application.Services.Contracts;
using NB.KingOfBeers.DataAccess;
using NB.KingOfBeers.Database.Context;

public class Startup
{
    /// <summary>
    /// Startup
    /// </summary>
    /// <param name="configuration"></param>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    /// <summary>
    /// Configuration
    /// </summary>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// ConfigureServices
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAutoMapper(typeof(StartupBase), typeof(BeerMapperProfile));

        services.AddValidatorsFromAssemblyContaining<AddBeerValidator>();

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IBeerService, BeerService>();
        services.AddTransient<IBreweryService, BreweryService>();
        services.AddTransient<IBreweryBeerService, BreweryBeerService>();

        services.AddDbContext<KobDataContext>(item =>
            {
                var conString = Configuration.GetConnectionString("sql_connection");
                if (string.IsNullOrWhiteSpace(conString))
                {
                    throw new InvalidOperationException("No connection string found");
                }
                item.UseSqlite(conString);
            });
    }

    /// <summary>
    /// Configure
    /// </summary>
    /// <param name="app"></param>
    public void Configure(IApplicationBuilder app)
    {
        app.UseHttpsRedirection();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseAuthorization();


        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });

        app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MorsesClub.Payments API");
            });

    }
}