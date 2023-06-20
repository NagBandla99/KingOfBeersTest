using NB.KingOfBeers.Application.Dtos;

namespace NB.KingOfBeers.Application.Services.Contracts;

/// <summary>
/// Service to manage beer entries in db.
/// </summary>
public interface IBeerService
{
    /// <summary>
    /// get all beer entries.
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyCollection<BeerDto>> GetAllAsync();

    /// <summary>
    /// Get entry by id.
    /// </summary>
    /// <param name="beerId"></param>
    /// <returns></returns>
    Task<BeerDto> GetById(int beerId);

    /// <summary>
    /// Search beers by Alcohol Volume.
    /// This is to search either by minimum volume or maximum volume.
    /// if needed to be combined, we could use between instead.
    /// </summary>
    /// <param name="searchBeers"></param>
    /// <returns></returns>
    Task<IReadOnlyCollection<BeerDto>> GetByAlcoholVolume(SearchBeers searchBeers);

    /// <summary>
    /// Update beer entry.
    /// </summary>
    /// <param name="updateBeerModel"></param>
    /// <returns></returns>
    Task<BeerDto> UpdateBeer(BeerDto updateBeerModel);
    
    /// <summary>
    /// Add new beer entry.
    /// </summary>
    /// <param name="addBeer"></param>
    /// <returns></returns>
    Task<bool> AddBeer(AddBeer addBeer);
}