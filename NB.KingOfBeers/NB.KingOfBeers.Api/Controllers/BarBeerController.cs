using NB.KingOfBeers.Application.Services.Contracts;
using NB.KingOfBeers.Application.Dtos.BarBeers;

namespace NB.KingOfBeers.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BarBeerController : ControllerBase
{
    private readonly IBarBeerService barBeerService;

    public BarBeerController(IBarBeerService barBeerService)
    {
        this.barBeerService = barBeerService ?? throw new ArgumentNullException(nameof(barBeerService));
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var getBeersResult = await this.barBeerService.GetAllAsync();

        return this.Ok(getBeersResult);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var getBeersResult = await this.barBeerService.GetById(id);

        return this.Ok(getBeersResult);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(AddBarBeer addBar)
    {
        var addBeerEntryResult = await this.barBeerService.AddBeer(addBar);

        return this.Ok(addBeerEntryResult);
    }

}