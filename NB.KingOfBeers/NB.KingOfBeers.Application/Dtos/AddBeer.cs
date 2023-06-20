namespace NB.KingOfBeers.Application.Dtos;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// beer DTO.
/// </summary>
public class AddBeer
{
    /// <summary>
    /// Beer name.
    /// </summary>
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }

    /// <summary>
    /// beer PercentageAlcoholByVolume.
    /// </summary>
    [Required]
    public decimal PercentageAlcoholByVolume { get; set; }
}