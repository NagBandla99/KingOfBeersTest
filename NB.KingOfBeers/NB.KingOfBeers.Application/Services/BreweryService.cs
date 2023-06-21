using NB.KingOfBeers.DataAccess;
using NB.KingOfBeers.Database.Models;
using NB.KingOfBeers.Application.Services.Contracts;
using NB.KingOfBeers.Database.Context;

namespace NB.KingOfBeers.Application.Services;

using NB.KingOfBeers.Application.Dtos.Brewery;

/// <inheritdoc />
public class BreweryService : IBreweryService
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<Brewery> breweryRepository;

    private readonly KobDataContext dbContext;

    public BreweryService(IMapper mapper, IGenericRepository<Brewery> breweryRepository, KobDataContext dbContext)
    {
        this.mapper = mapper;
        this.breweryRepository = breweryRepository;
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<BreweryDto>> GetAllAsync()
    {
        var beers = await this.breweryRepository.GetWhere(x => !x.IsDeleted);

        return this.mapper.Map<IReadOnlyCollection<BreweryDto>>(beers);
    }

    /// <inheritdoc />
    public async Task<BreweryDto> GetById(int breweryId)
    {
        var beers = await this.breweryRepository.FirstOrDefault(x => !x.IsDeleted && x.BreweryId == breweryId);

        return this.mapper.Map<BreweryDto>(beers);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<BreweryDto>> SearchByNameAsync(string brewery)
    {
        var beerEntries = (from b in this.dbContext.Brewery
                           where !b.IsDeleted
                           where b.Name.ToLower().StartsWith(brewery.ToLower())
                           select new BreweryDto
                           {
                               BreweryId = b.BreweryId,
                               Name = b.Name
                           }).AsQueryable();
        
        var beers = await beerEntries.ToListAsync();

        return beers;
    }

    /// <inheritdoc />
    public async Task<BreweryDto> UpdateBrewery(BreweryDto updateBrewery)
    {
        var beer = await this.breweryRepository.FirstOrDefault(x => x.BreweryId == updateBrewery.BreweryId);

        if (beer == null)
        {
            throw new KeyNotFoundException($"Entry not found with given value {updateBrewery.BreweryId}");
        }

        beer.Name = updateBrewery.Name;

        await this.breweryRepository.Update(beer);

        return this.mapper.Map<BreweryDto>(beer);
    }


    /// <inheritdoc />
    public async Task<bool> AddBrewery(AddBrewery addBeer)
    {
        var beer = await this.breweryRepository.FirstOrDefault(x => x.Name.Equals(addBeer.Name));

        if (beer != null)
        {
            throw new InvalidOperationException($"Entry with beer {addBeer.Name} already exists.");
        }

        await this.breweryRepository.Add(new Brewery
        {
            IsDeleted = false,
            Name = addBeer.Name
        });

        return true;
    }
}