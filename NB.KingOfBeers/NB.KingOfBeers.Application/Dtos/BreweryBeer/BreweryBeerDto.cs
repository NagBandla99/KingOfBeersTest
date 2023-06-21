using NB.KingOfBeers.Application.Dtos.Brewery;


namespace NB.KingOfBeers.Application.Dtos.BreweryBeer;

public class BreweryBeerDto
{
    public int BreweryBeerId { get; set; }

    /// <summary>
    /// Brewery Id.
    /// </summary>
    public int BreweryId { get; set; }

    /// <summary>
    /// Beer id.
    /// </summary>
    public int BeerId { get; set; }

    public virtual BreweryDto Brewery { get; set; }

    public virtual BeerDto Beer { get; set; }

}