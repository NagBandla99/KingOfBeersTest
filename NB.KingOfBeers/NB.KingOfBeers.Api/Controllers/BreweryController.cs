using NB.KingOfBeers.Api.Extension;
using NB.KingOfBeers.Application.Services.Contracts;

namespace NB.KingOfBeers.Api.Controllers;

using NB.KingOfBeers.Application.Dtos.Brewery;

[ApiController]
[Route("[controller]")]
public class BreweryController : ControllerBase
{
    private readonly IBreweryService breweryService;
    private readonly ILogger<BreweryController> logger;
    private readonly IValidator<AddBrewery> breweryDtoValidator;

    public BreweryController(ILogger<BreweryController> logger, IBreweryService breweryService, IValidator<AddBrewery> breweryDtoValidator)
    {
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this.breweryService = breweryService ?? throw new ArgumentNullException(nameof(breweryService));
        this.breweryDtoValidator = breweryDtoValidator ?? throw new ArgumentNullException(nameof(breweryDtoValidator));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var result = await this.breweryService.GetById(id);

        return this.Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await this.breweryService.GetAllAsync();

        return this.Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> SearchBeerAsync([FromQuery] string searchBrewery)
    {
        var result = await this.breweryService.SearchByNameAsync(searchBrewery);

        return this.Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(AddBrewery addBrewery, CancellationToken cancellationToken)
    {
        var validation = await this.breweryDtoValidator.ValidateAsync(addBrewery, cancellationToken);

        if (!validation.IsValid)
        {
            this.logger.LogInformation("Invalid attempt to add new beer entry.");
            return this.FluentValidationProblem(validation);
        }

        var result = await this.breweryService.AddBrewery(addBrewery);

        return this.Ok(result);
    }

    [HttpPut("{BeerId:int}")]
    public async Task<IActionResult> UpdateBeerAsync(BreweryDto updateBrewery)
    {
        var result = await this.breweryService.UpdateBrewery(updateBrewery);

        return this.Ok(result);
    }
}