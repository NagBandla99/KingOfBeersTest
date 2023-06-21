using NB.KingOfBeers.Application.Dtos;
using NB.KingOfBeers.Database.Models;

namespace NB.KingOfBeers.Api.IntegrationTests.Controllers;

public class BeerControllerTests : IClassFixture<KobApplicationFactory<Startup>>
{
    private readonly KobApplicationFactory<Startup> webApplicationFactory;
    private readonly Fixture fixture;

    public BeerControllerTests(KobApplicationFactory<Startup> webApplicationFactory)
    {
        fixture = new Fixture();
        this.webApplicationFactory = webApplicationFactory;
    }

    [Fact]
    public async Task GetBeerById_WhenGivenValidId_ShouldReturnValidEntry()
    {
        // Arrange
        var beerEWwntryId = 1;

        var mockedBeers = fixture.Build<Beer>()
            .With(x => x.IsDeleted, false)
            .With(x => x.PercentageAlcoholByVolume, 4)
            .With(x => x.BeerId, 1)
            .Create();

        var client = webApplicationFactory.CreateClient();
        webApplicationFactory.BeerRepo
            .Setup(x => x.FirstOrDefault(It.IsAny<Expression<Func<Beer, bool>>>()))
            .ReturnsAsync(mockedBeers);

        // Act
        var response = await client.GetAsync($"beer/{beerEWwntryId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<BeerDto>();

        content.Should().NotBeNull();
    }
    
    [Fact]
    public async Task GetBeerById_WhenGivenInvalidId_ShouldReturnNothing()
    {
        // Arrange
        var beerEWwntryId = 0;

        var client = webApplicationFactory.CreateClient();
        webApplicationFactory.BeerRepo
            .Setup(x => x.FirstOrDefault(It.IsAny<Expression<Func<Beer, bool>>>()))
            .ReturnsAsync((Beer)null);

        // Act
        var response = await client.GetAsync($"beer/{beerEWwntryId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}