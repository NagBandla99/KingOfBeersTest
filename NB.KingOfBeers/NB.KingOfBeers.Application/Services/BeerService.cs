using NB.KingOfBeers.Application.Dtos;
using NB.KingOfBeers.DataAccess;
using NB.KingOfBeers.Database.Models;
using NB.KingOfBeers.Application.Services.Contracts;
using NB.KingOfBeers.Database.Context;

namespace NB.KingOfBeers.Application.Services;

/// <inheritdoc />
public class BeerService : IBeerService
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<Beer> beeRepository;

    private readonly KobDataContext dbContext;

    public BeerService(IMapper mapper, IGenericRepository<Beer> beeRepository, KobDataContext dbContext)
    {
        this.mapper = mapper;
        this.beeRepository = beeRepository;
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<BeerDto>> GetAllAsync()
    {
        var beers = await this.beeRepository.GetWhere(x => !x.IsDeleted);

        return this.mapper.Map<IReadOnlyCollection<BeerDto>>(beers);
    }

    /// <inheritdoc />
    public async Task<BeerDto> GetById(int beerId)
    {
        var beers = await this.beeRepository.FirstOrDefault(x => !x.IsDeleted && x.BeerId == beerId);

        return this.mapper.Map<BeerDto>(beers);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<BeerDto>> GetByAlcoholVolume(SearchBeers searchBeers)
    {
        var beerEntries = (from b in this.dbContext.Beer
                           where !b.IsDeleted
                           select new BeerDto
                           {
                               BeerId = b.BeerId,
                               PercentageAlcoholByVolume = b.PercentageAlcoholByVolume,
                               Name = b.Name
                           }).AsQueryable();

        if (searchBeers.MinimumAlcoholVolume > 0)
        {
            beerEntries = beerEntries.Where(x => x.PercentageAlcoholByVolume >= searchBeers.MinimumAlcoholVolume).AsQueryable();
        }

        if (searchBeers.MaximumAlcoholVolume > 0)
        {
            beerEntries = beerEntries.Where(x => x.PercentageAlcoholByVolume <= searchBeers.MaximumAlcoholVolume).AsQueryable();
        }

        var beers = await beerEntries.ToListAsync();

        return beers;
    }

    /// <inheritdoc />
    public async Task<BeerDto> UpdateBeer(BeerDto updateBeerModel)
    {
        var beer = await this.beeRepository.FirstOrDefault(x => x.BeerId == updateBeerModel.BeerId);

        if (beer == null)
        {
            throw new KeyNotFoundException($"Entry not found with given value {updateBeerModel.BeerId}");
        }

        beer.Name = updateBeerModel.Name;
        beer.PercentageAlcoholByVolume = updateBeerModel.PercentageAlcoholByVolume;

        await this.beeRepository.Update(beer);

        return this.mapper.Map<BeerDto>(beer);
    }


    /// <inheritdoc />
    public async Task<bool> AddBeer(AddBeer addBeer)
    {
        var beer = await this.beeRepository.FirstOrDefault(x => x.Name.Equals(addBeer.Name));

        if (beer != null)
        {
            throw new InvalidOperationException($"Entry with beer {addBeer.Name} already exists.");
        }

        await this.beeRepository.Add(new Beer
        {
            IsDeleted = false,
            Name = addBeer.Name,
            PercentageAlcoholByVolume = addBeer.PercentageAlcoholByVolume
        });

        return true;
    }
}