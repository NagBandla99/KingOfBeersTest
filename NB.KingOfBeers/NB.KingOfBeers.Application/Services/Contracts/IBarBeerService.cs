namespace NB.KingOfBeers.Application.Services.Contracts;

using NB.KingOfBeers.Application.Dtos.BarBeers;

/// <summary>
/// Service to manage beer entries in db.
/// </summary>
public interface IBarBeerService
{
    /// <summary>
    /// get all beer entries.
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyCollection<BarBeersDto>> GetAllAsync();

    /// <summary>
    /// Get entry by id.
    /// </summary>
    /// <param name="barId"></param>
    /// <returns></returns>
    Task<BarBeersDto> GetById(int barId);
    
    /// Add new beer entry.
    /// </summary>
    /// <param name="addBeer"></param>
    /// <returns></returns>
    Task<bool> AddBeer(AddBarBeer addbARBeer);
}