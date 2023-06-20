using NB.KingOfBeers.Api.Validators;
using NB.KingOfBeers.Application.Dtos;

namespace NB.KingOfBeers.Api.Tests.Validators
{
    public class AddBeerValidatorTests
    {
        private readonly IFixture fixture;
        private readonly AddBeerValidator validator;
        public AddBeerValidatorTests()
        {
            fixture = new Fixture();
            validator = new AddBeerValidator();
        }

        [Fact]
        public void Validate_With_ValidRequest_ReturnsTrue()
        {
            var createProductionAppCredentials = fixture.Build<AddBeer>()
                .With(x => x.Name, "Budwiser")
                .Create();
            var result = validator.Validate(createProductionAppCredentials);

            result.IsValid.Should().BeTrue();
        }


        [Theory]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData(null, false)]
        [InlineData("kdsfjghkldfsjghdflksjghkldfj", false)]
        [InlineData("aa", false)]
        public void Validate_WithInvalid_Name_IsNotValid(string name, bool expectedOutcome)
        {
            var createProductionAppCredentials = fixture.Build<AddBeer>()
                .With(x => x.Name, name)

                .Create();

            var result = validator.Validate(createProductionAppCredentials);

            result.IsValid.Should().Be(expectedOutcome);
        }
    }
}
