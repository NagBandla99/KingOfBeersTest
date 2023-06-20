using NB.KingOfBeers.Application.Dtos;

namespace NB.KingOfBeers.Api.Validators;

/// <summary>
/// Add beer model validator.
/// </summary>
public class AddBeerValidator : AbstractValidator<AddBeer>
{
    public AddBeerValidator() : base()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(3, 20);

        RuleFor(x => x.PercentageAlcoholByVolume).NotNull();
    }
}