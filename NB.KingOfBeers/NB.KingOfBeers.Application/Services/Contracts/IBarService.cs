using NB.KingOfBeers.Application.Dtos.Bar;

namespace NB.KingOfBeers.Application.Services.Contracts;

/// <summary>
/// Service to manage beer entries in db.
/// </summary>
public interface IBarService
{
    /// <summary>
    /// get all beer entries.
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyCollection<BarDto>> GetAllAsync();

    /// <summary>
    /// Get entry by id.
    /// </summary>
    /// <param name="barId"></param>
    /// <returns></returns>
    Task<BarDto> GetById(int barId);
    
    /// <summary>
    /// Update beer entry.
    /// </summary>
    /// <param name="updateBeerModel"></param>
    /// <returns></returns>
    Task<BarDto> UpdateBar(Updatebar updateBar);
    
    /// <summary>
    /// Add new beer entry.
    /// </summary>
    /// <param name="addBeer"></param>
    /// <returns></returns>
    Task<bool> AddBeer(AddBar addBeer);
}