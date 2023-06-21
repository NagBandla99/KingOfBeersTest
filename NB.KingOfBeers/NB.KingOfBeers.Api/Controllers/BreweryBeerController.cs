using NB.KingOfBeers.Application.Services.Contracts;

namespace NB.KingOfBeers.Api.Controllers;

using NB.KingOfBeers.Application.Dtos.BreweryBeer;

[ApiController]
[Route("[controller]")]
public class BreweryBeerController : ControllerBase
{
    private readonly IBreweryBeerService breweryBeerService;

    public BreweryBeerController(IBreweryBeerService breweryBeerService)
    {
        this.breweryBeerService = breweryBeerService ?? throw new ArgumentNullException(nameof(breweryBeerService));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var result = await this.breweryBeerService.GetByIdAsync(id);

        return this.Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await this.breweryBeerService.GetAllAsync();

        return this.Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(AddBreweryBeer addBreweryBeer, CancellationToken cancellationToken)
    {
        var result = await this.breweryBeerService.AddBrewery(addBreweryBeer);

        return this.Ok(result);
    }

    [HttpPut("{BeerId:int}")]
    public async Task<IActionResult> UpdateBeerAsync(UpdateBreweryBeer updateBrewery)
    {
        var result = await this.breweryBeerService.UpdateBrewery(updateBrewery);

        return this.Ok(result);
    }
}