namespace NB.KingOfBeers.Database.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Bar
{
    /// <summary>
    /// Identity column.
    /// </summary>
    [Key]
    public int BarId { get; set; }

    /// <summary>
    /// Name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Is active flag.
    /// </summary>
    public bool IsDeleted { get; set; }

    public virtual ICollection<Brewery> Breweries { get; set; } = new List<Brewery>();
}