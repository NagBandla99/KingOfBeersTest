namespace NB.KingOfBeers.Application.Dtos;

/// <summary>
/// Search beers.
/// </summary>
public  class SearchBeers
{
    public SearchBeers()
    {

    }

    /// <summary>
    /// Minimum Alcohol Volume.
    /// </summary>
    public decimal MinimumAlcoholVolume { get; set; } = decimal.Zero;

    /// <summary>
    /// Maximum Alcohol Volume.
    /// </summary>
    public decimal MaximumAlcoholVolume { get; set; } = decimal.Zero;
}