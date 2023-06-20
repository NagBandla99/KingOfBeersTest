using System.ComponentModel.DataAnnotations;

namespace NB.KingOfBeers.Database.Models;

/// <summary>
/// Beer model.
/// </summary>
public class Beer
{
    /// <summary>
    /// Identity column.
    /// </summary>
    [Key]
    public int BeerId { get; set; }

    /// <summary>
    /// Name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Alcohol percentage.
    /// </summary>
    public decimal PercentageAlcoholByVolume { get; set; }

    /// <summary>
    /// Is active flag.
    /// </summary>
    public bool IsDeleted { get; set; }
}