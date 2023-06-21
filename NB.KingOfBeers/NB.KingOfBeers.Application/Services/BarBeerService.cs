using NB.KingOfBeers.DataAccess;
using NB.KingOfBeers.Database.Models;
using NB.KingOfBeers.Application.Services.Contracts;
using NB.KingOfBeers.Database.Context;
using NB.KingOfBeers.Application.Dtos.BarBeers;
using NB.KingOfBeers.Application.Dtos;

namespace NB.KingOfBeers.Application.Services;


/// <inheritdoc />
public class BarBeerService : IBarBeerService
{
    private readonly IGenericRepository<BarBeers> barBeerRepository;

    private readonly KobDataContext dbContext;

    public BarBeerService(IGenericRepository<BarBeers> barBeerRepository, KobDataContext dbContext)
    {
        this.barBeerRepository = barBeerRepository;
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<BarBeersDto>> GetAllAsync()
    {

        var bars = (from bar in dbContext.Bar
                    select new BarBeersDto
                    {
                        BarId = bar.BarId,
                        BarName = bar.Name,
                        Beer = (from beers in dbContext.BarBeer
                                where beers.BarId == bar.BarId
                                select new BeerDto
                                {
                                    BeerId = beers.BeerId,
                                    Name = beers.Beer.Name,
                                    PercentageAlcoholByVolume = beers.Beer.PercentageAlcoholByVolume,
                                }).ToList()
                    }).ToListAsync();

        return await bars;

    }

    /// <inheritdoc />
    public async Task<BarBeersDto> GetById(int barId)
    {
        return await (from bar in dbContext.Bar
                      where bar.BarId == barId
                      select new BarBeersDto
                      {
                          BarId = bar.BarId,
                          BarName = bar.Name,
                          Beer = (from beers in dbContext.BarBeer
                                  where beers.BarId == bar.BarId
                                  select new BeerDto
                                  {
                                      BeerId = beers.BeerId,
                                      Name = beers.Beer.Name,
                                      PercentageAlcoholByVolume = beers.Beer.PercentageAlcoholByVolume,
                                  }).ToList()
                      }).FirstOrDefaultAsync();
    }

    /// <inheritdoc />
    public async Task<bool> AddBeer(AddBarBeer addbARBeer)
    {
        var beer = await this.barBeerRepository.FirstOrDefault(x => x.BarId.Equals(addbARBeer.BarId) && x.BreweryId.Equals(addbARBeer.BarId) && x.BeerId.Equals(addbARBeer.BeerId));

        if (beer != null)
        {
            throw new InvalidOperationException($"Entry already exists.");
        }

        await this.barBeerRepository.Add(new BarBeers
        {
            BarId = addbARBeer.BarId,
            BreweryId = addbARBeer.BreweryId,
            BeerId = addbARBeer.BeerId,
        });

        return true;
    }
}