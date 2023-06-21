using NB.KingOfBeers.DataAccess;
using NB.KingOfBeers.Database.Models;
using NB.KingOfBeers.Application.Services.Contracts;
using NB.KingOfBeers.Application.Dtos.Bar;

namespace NB.KingOfBeers.Application.Services;

/// <inheritdoc />
public class BarService : IBarService
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<Bar> barRepository;


    public BarService(IMapper mapper, IGenericRepository<Bar> barRepository)
    {
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this.barRepository = barRepository ?? throw new ArgumentNullException(nameof(barRepository));
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<BarDto>> GetAllAsync()
    {
        var beers = await this.barRepository.GetWhere(x => !x.IsDeleted);

        return this.mapper.Map<IReadOnlyCollection<BarDto>>(beers);
    }

    /// <inheritdoc />
    public async Task<BarDto> GetById(int barId)
    {
        var beers = await this.barRepository.FirstOrDefault(x => !x.IsDeleted && x.BarId == barId);

        return this.mapper.Map<BarDto>(beers);
    }


    /// <inheritdoc />
    public async Task<BarDto> UpdateBar(Updatebar updateBar)
    {
        var beer = await this.barRepository.FirstOrDefault(x => x.BarId == updateBar.BarId);

        if (beer == null)
        {
            throw new KeyNotFoundException($"Entry not found with given value {updateBar.BarId}");
        }

        beer.Name = updateBar.Name;

        await this.barRepository.Update(beer);

        return this.mapper.Map<BarDto>(beer);
    }


    /// <inheritdoc />
    public async Task<bool> AddBeer(AddBar addBeer)
    {
        var beer = await this.barRepository.FirstOrDefault(x => x.Name.Equals(addBeer.Name));

        if (beer != null)
        {
            throw new InvalidOperationException($"Entry with beer {addBeer.Name} already exists.");
        }

        await this.barRepository.Add(new Bar
        {
            IsDeleted = false,
            Name = addBeer.Name
        });

        return true;
    }
}