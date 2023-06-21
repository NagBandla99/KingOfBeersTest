namespace NB.KingOfBeers.Application.Dtos.BarBeers;

public class BarBeersDto
{
    public int BarId { get; set; }

    public string BarName { get; set; }

    public IReadOnlyCollection<BeerDto> Beer { get; set; }
}