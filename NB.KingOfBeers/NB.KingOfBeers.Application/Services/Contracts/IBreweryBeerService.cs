using NB.KingOfBeers.Application.Dtos.Brewery;

namespace NB.KingOfBeers.Application.Services.Contracts;

using NB.KingOfBeers.Application.Dtos.BreweryBeer;

/// <summary>
/// Service to manage beer entries in db.
/// </summary>
public interface IBreweryBeerService
{
    /// <summary>
    /// get all beer entries.
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyCollection<BreweryBeerDto>> GetAllAsync();

    /// <summary>
    /// Get entry by id.
    /// </summary>
    /// <param name="breweryId"></param>
    /// <returns></returns>
    Task<BreweryBeerDto> GetByIdAsync(int breweryBeerId);
    
    /// <summary>
    /// Update beer entry.
    /// </summary>
    /// <param name="updateBreweryBeer"></param>
    /// <returns></returns>
    Task<BreweryBeerDto> UpdateBrewery(UpdateBreweryBeer updateBreweryBeer);
    
    /// <summary>
    /// Add new beer entry.
    /// </summary>
    /// <param name="addBreweryBeer"></param>
    /// <returns></returns>
    Task<bool> AddBrewery(AddBreweryBeer addBreweryBeer);
}