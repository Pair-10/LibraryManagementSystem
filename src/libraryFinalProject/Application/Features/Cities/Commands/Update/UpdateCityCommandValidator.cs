using FluentValidation;

namespace Application.Features.Cities.Commands.Update;

public class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommand>
{
    public UpdateCityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CountryId).NotEmpty();
        RuleFor(c => c.CityName).NotEmpty().MinimumLength(2).MaximumLength(15);
    }
}