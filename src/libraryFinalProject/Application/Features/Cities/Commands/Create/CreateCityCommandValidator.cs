using FluentValidation;

namespace Application.Features.Cities.Commands.Create;

public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
{
    public CreateCityCommandValidator()
    {
        RuleFor(c => c.CountryId).NotEmpty();
        RuleFor(c => c.CityName).NotEmpty().MinimumLength(2).MaximumLength(15);
    }
}