using FluentValidation;

namespace Application.Features.Penalties.Commands.Create;

public class CreatePenaltyCommandValidator : AbstractValidator<CreatePenaltyCommand>
{
    public CreatePenaltyCommandValidator()
    {
        RuleFor(c => c.ReturnedId).NotEmpty();
        RuleFor(c => c.PenaltyPrice).NotEmpty().GreaterThan(0);
        RuleFor(c => c.TotalPenaltyDays).NotEmpty();

        RuleFor(c => c.PenaltyStatus).NotEmpty();
        RuleFor(c => c.PaymentId).NotEmpty();
    }
}