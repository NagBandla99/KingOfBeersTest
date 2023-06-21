using System.ComponentModel.DataAnnotations;

namespace NB.KingOfBeers.Database.Models;

public class BreweryBeer
{
    /// <summary>
    /// Brewery Beer Id.
    /// </summary>
    [Key]
    public int BreweryBeerId { get; set; }

    /// <summary>
    /// Brewery Id.
    /// </summary>
    public int BreweryId { get; set; }

    /// <summary>
    /// Beer id.
    /// </summary>
    public int BeerId { get; set; }

    public virtual Brewery Brewery { get; set; }

    public virtual Beer Beer { get; set; }
}