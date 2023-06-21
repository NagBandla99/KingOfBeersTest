using NB.KingOfBeers.Application.Dtos.Brewery;

namespace NB.KingOfBeers.Application.Services.Contracts;

/// <summary>
/// Service to manage beer entries in db.
/// </summary>
public interface IBreweryService
{
    /// <summary>
    /// get all beer entries.
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyCollection<BreweryDto>> GetAllAsync();

    /// <summary>
    /// Get entry by id.
    /// </summary>
    /// <param name="breweryId"></param>
    /// <returns></returns>
    Task<BreweryDto> GetById(int breweryId);

    /// <summary>
    /// Search beers by Alcohol Volume.
    /// This is to search either by minimum volume or maximum volume.
    /// if needed to be combined, we could use between instead.
    /// </summary>
    /// <param name="brewery"></param>
    /// <returns></returns>
    Task<IReadOnlyCollection<BreweryDto>> SearchByNameAsync(string brewery);

    /// <summary>
    /// Update beer entry.
    /// </summary>
    /// <param name="updateBrewery"></param>
    /// <returns></returns>
    Task<BreweryDto> UpdateBrewery(BreweryDto updateBrewery);
    
    /// <summary>
    /// Add new beer entry.
    /// </summary>
    /// <param name="addBeer"></param>
    /// <returns></returns>
    Task<bool> AddBrewery(AddBrewery addBeer);
}