using FluentValidation;

namespace Application.Features.Streets.Commands.Update;

public class UpdateStreetCommandValidator : AbstractValidator<UpdateStreetCommand>
{
    public UpdateStreetCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.DistrictId).NotEmpty();
        RuleFor(c => c.StreetName).NotEmpty().MinimumLength(2);
    }
}