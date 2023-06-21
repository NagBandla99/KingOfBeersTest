namespace NB.KingOfBeers.Application.Dtos;

/// <summary>
/// beer DTO.
/// </summary>
public class BeerDto
{
    /// <summary>
    /// beer entry id.
    /// </summary>
    public int BeerId { get; set; }

    /// <summary>
    /// Beer name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// beer PercentageAlcoholByVolume.
    /// </summary>
    public decimal PercentageAlcoholByVolume { get; set; }
}