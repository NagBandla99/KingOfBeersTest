using NB.KingOfBeers.Application.Services.Contracts;

namespace NB.KingOfBeers.Api.Controllers
{
    using NB.KingOfBeers.Application.Dtos.Bar;

    [ApiController]
    [Route("[controller]")]
    public class BarController : ControllerBase
    {
        private readonly IBarService barService;

        public BarController(IBarService barService)
        {
            this.barService = barService ?? throw new ArgumentNullException(nameof(barService));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var getBeersResult = await this.barService.GetAllAsync();

            return this.Ok(getBeersResult);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var getBeersResult = await this.barService.GetById(id);

            return this.Ok(getBeersResult);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(AddBar addBar, CancellationToken cancellationToken)
        {

            var addBeerEntryResult = await this.barService.AddBeer(addBar);

            return this.Ok(addBeerEntryResult);
        }

        [HttpPut("{BarId:int}")]
        public async Task<IActionResult> UpdateBeerAsync(Updatebar updateBar)
        {
            var getBeersResult = await this.barService.UpdateBar(updateBar);

            return this.Ok(getBeersResult);
        }
    }
}