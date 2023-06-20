using NB.KingOfBeers.Application.Services;
using NB.KingOfBeers.DataAccess;
using NB.KingOfBeers.Database.Context;
using NB.KingOfBeers.Database.Models;
using NB.KingOfBeers.Application.Dtos;

namespace NB.KingOfBeers.Application.Tests;

public class BeerServiceTests
{
    private readonly IFixture fixture;
    private readonly Mock<IMapper> mapperMock;
    private readonly DbContextMock<KobDataContext> dbContextMock;
    private readonly BeerService _sut;

    public BeerServiceTests()
    {
        fixture = new Fixture();
        mapperMock = new Mock<IMapper>();
        var beerRepoMock = new Mock<IGenericRepository<Beer>>();
        dbContextMock = new DbContextMock<KobDataContext>();

        _sut = new BeerService(this.mapperMock.Object, beerRepoMock.Object, this.dbContextMock.Object);
    }

    [Fact]
    public async Task GetByAlcoholVolume_WhenCalled_ShouldReturnExpectedEntries()
    {
        // Arrange 
        var alchVolume = Convert.ToDecimal(4.5);
        var beersMocked = this.fixture.Build<Beer>()
            .With(x => x.IsDeleted, false)
            .With(x => x.PercentageAlcoholByVolume, alchVolume)
            .CreateMany(4);

        dbContextMock.CreateDbSetMock(x => x.Beer, beersMocked);
        var searchBeers = new SearchBeers { MaximumAlcoholVolume = 10, MinimumAlcoholVolume = 0 };
        // Act
        var result = await this._sut.GetByAlcoholVolume(searchBeers);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(beersMocked, config =>
            config
                .Excluding(ctx => ctx.IsDeleted)
        );
    }


    [Fact]
    public async Task GetByAlcoholVolume_WhenCalled_ShouldReturnNothing()
    {
        // Arrange 
        var alchVolume = Convert.ToDecimal(4.5);
        var beersMocked = this.fixture.Build<Beer>()
            .With(x => x.IsDeleted, false)
            .With(x => x.PercentageAlcoholByVolume, alchVolume)
            .CreateMany(4);

        dbContextMock.CreateDbSetMock(x => x.Beer, beersMocked);
        var searchBeers = new SearchBeers { MaximumAlcoholVolume = 3, MinimumAlcoholVolume = 0 };
        // Act
        var result = await this._sut.GetByAlcoholVolume(searchBeers);

        result.Should().BeEmpty();
    }
}