using NB.KingOfBeers.Api.Extension;
using NB.KingOfBeers.Application.Dtos;
using NB.KingOfBeers.Application.Services.Contracts;

namespace NB.KingOfBeers.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BeerController : ControllerBase
    {

        private readonly IBeerService beerService;
        private readonly ILogger<BeerController> logger;
        private readonly IValidator<AddBeer> beerDtoValidator;

        public BeerController(ILogger<BeerController> logger, IBeerService beerService, IValidator<AddBeer> beerDtoValidator)
        {
            this.logger = logger;
            this.beerService = beerService ?? throw new ArgumentNullException(nameof(beerService));
            this.beerDtoValidator = beerDtoValidator ?? throw new ArgumentNullException(nameof(beerDtoValidator));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var getBeersResult = await this.beerService.GetById(id);

            return this.Ok(getBeersResult);
        }


        [HttpGet]
        public async Task<IActionResult> SearchBeerAsync([FromQuery]SearchBeers searchBeer)
        {
            var getBeersResult = await this.beerService.GetByAlcoholVolume(searchBeer);

            return this.Ok(getBeersResult);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(AddBeer beerDto, CancellationToken cancellationToken)
        {
            var validation = await this.beerDtoValidator.ValidateAsync(beerDto, cancellationToken);

            if (!validation.IsValid)
            {
                return this.FluentValidationProblem(validation);
            }

            var addBeerEntryResult = await this.beerService.AddBeer(beerDto);

            return this.Ok(addBeerEntryResult);
        }


        [HttpPut("{BeerId:int}")]
        public async Task<IActionResult> UpdateBeerAsync(BeerDto updateBeer)
        {
            var getBeersResult = await this.beerService.UpdateBeer(updateBeer);

            return this.Ok(getBeersResult);
        }
    }
}