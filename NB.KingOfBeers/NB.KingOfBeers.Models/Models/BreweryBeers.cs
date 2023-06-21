using System.ComponentModel.DataAnnotations;

namespace NB.KingOfBeers.Database.Models;

public class BreweryBeers
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

    public Brewery Brewery { get; set; }

    public Beer Beer { get; set; }
}