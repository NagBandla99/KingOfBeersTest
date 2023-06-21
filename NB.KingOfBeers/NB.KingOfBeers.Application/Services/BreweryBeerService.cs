using NB.KingOfBeers.DataAccess;
using NB.KingOfBeers.Database.Models;
using NB.KingOfBeers.Application.Services.Contracts;
using NB.KingOfBeers.Application.Dtos.BreweryBeer;

namespace NB.KingOfBeers.Application.Services;

using NB.KingOfBeers.Database.Context;

/// <inheritdoc />
public class BreweryBeerService : IBreweryBeerService
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<BreweryBeers> breweryBeerRepository;

    private readonly KobDataContext dataContext;

    public BreweryBeerService(IMapper mapper, IGenericRepository<BreweryBeers> breweryBeerRepository, KobDataContext dataContext)
    {
        this.mapper = mapper;
        this.breweryBeerRepository = breweryBeerRepository;
        this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<BreweryBeerDto>> GetAllAsync()
    {
        var breweryBeer = await this.dataContext.BreweryBeer
                              .Include(x => x.Beer)
                              .Include(x => x.Brewery)
                              .ToListAsync();
        return this.mapper.Map<IReadOnlyCollection<BreweryBeerDto>>(breweryBeer);
    }

    /// <inheritdoc />
    public async Task<BreweryBeerDto> GetByIdAsync(int breweryBeerId)
    {
        var breweryBeer = await this.dataContext.BreweryBeer
            .Where(x => x.BreweryBeerId == breweryBeerId)
            .Include(x => x.Beer)
            .Include(x => x.Brewery)
            .FirstOrDefaultAsync();

        return this.mapper.Map<BreweryBeerDto>(breweryBeer);
    }
    
    /// <inheritdoc />
    public async Task<BreweryBeerDto> UpdateBrewery(UpdateBreweryBeer updateBreweryBeer)
    {
        var beer = await this.breweryBeerRepository.FirstOrDefault(x => x.BreweryId == updateBreweryBeer.BreweryId);

        if (beer == null)
        {
            throw new KeyNotFoundException($"Entry not found with given value {updateBreweryBeer.BreweryId}");
        }

        beer.BeerId = updateBreweryBeer.BeerId;
        beer.BreweryId = updateBreweryBeer.BreweryId;

        await this.breweryBeerRepository.Update(beer);

        return this.mapper.Map<BreweryBeerDto>(beer);
    }


    /// <inheritdoc />
    public async Task<bool> AddBrewery(AddBreweryBeer addBreweryBeer)
    {
        var beer = await this.breweryBeerRepository
                       .FirstOrDefault(x => x.BeerId == addBreweryBeer.BeerId && x.BreweryId == addBreweryBeer.BreweryId);

        if (beer != null)
        {
            throw new InvalidOperationException($"Entry with Brewery id {addBreweryBeer.BreweryId} and beer id {addBreweryBeer.BeerId} already exists.");
        }

        await this.breweryBeerRepository.Add(new BreweryBeers
        {
            BeerId = addBreweryBeer.BeerId,
            BreweryId = addBreweryBeer.BreweryId
        });

        return true;
    }
}