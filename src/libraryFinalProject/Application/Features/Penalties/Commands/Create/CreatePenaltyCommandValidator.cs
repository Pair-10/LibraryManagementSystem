using FluentValidation;

namespace Application.Features.Penalties.Commands.Create;

public class CreatePenaltyCommandValidator : AbstractValidator<CreatePenaltyCommand>
{
    public CreatePenaltyCommandValidator()
    {
        RuleFor(c => c.ReturnId).NotEmpty();
        RuleFor(c => c.PenaltyPrice).NotEmpty();
        RuleFor(c => c.PenaltyDate).NotEmpty();
        RuleFor(c => c.PenaltyStatus).NotEmpty();
    }
}