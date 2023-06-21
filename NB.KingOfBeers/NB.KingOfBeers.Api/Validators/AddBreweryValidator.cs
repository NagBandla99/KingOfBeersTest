namespace NB.KingOfBeers.Api.Validators;

using NB.KingOfBeers.Application.Dtos.Brewery;

/// <summary>
/// Add beer model validator.
/// </summary>
public class AddBreweryValidator : AbstractValidator<AddBrewery>
{
    public AddBreweryValidator() : base()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(3, 20);
    }
}