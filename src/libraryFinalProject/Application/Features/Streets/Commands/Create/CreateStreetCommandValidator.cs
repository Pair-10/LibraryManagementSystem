using FluentValidation;

namespace Application.Features.Streets.Commands.Create;

public class CreateStreetCommandValidator : AbstractValidator<CreateStreetCommand>
{
    public CreateStreetCommandValidator()
    {
        RuleFor(c => c.DistrictId).NotEmpty();
        RuleFor(c => c.StreetName).NotEmpty();
    }
}