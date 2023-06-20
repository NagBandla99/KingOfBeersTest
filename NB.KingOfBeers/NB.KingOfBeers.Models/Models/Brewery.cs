namespace NB.KingOfBeers.Database.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Brewery model.
/// </summary>
public class Brewery
{
    /// <summary>
    /// Brewery id.
    /// </summary>
    [Key]
    public int BreweryId { get; set; }

    /// <summary>
    /// Brewery name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Is active flag.
    /// </summary>
    public bool IsDeleted { get; set; }

    public virtual ICollection<Beer> Beers { get; set; } = new List<Beer>();
}