namespace NB.KingOfBeers.Application.Dtos.Brewery;

/// <summary>
/// BreweryDto.
/// </summary>
public class BreweryDto
{
    /// <summary>
    /// Brewery Id.
    /// </summary>
    public int BreweryId { get; set; }

    /// <summary>
    /// Brewery name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Is active flag.
    /// </summary>
    public bool IsDeleted { get; set; }
}