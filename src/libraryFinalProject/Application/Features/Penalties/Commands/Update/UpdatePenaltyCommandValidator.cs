using FluentValidation;

namespace Application.Features.Penalties.Commands.Update;

public class UpdatePenaltyCommandValidator : AbstractValidator<UpdatePenaltyCommand>
{
    public UpdatePenaltyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ReturnId).NotEmpty();
        RuleFor(c => c.PenaltyPrice).NotEmpty();
        RuleFor(c => c.PenaltyDate).NotEmpty();
        RuleFor(c => c.PenaltyStatus).NotEmpty();
    }
}