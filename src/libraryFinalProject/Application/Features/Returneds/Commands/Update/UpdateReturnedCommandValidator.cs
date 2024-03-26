using FluentValidation;

namespace Application.Features.Returneds.Commands.Update;

public class UpdateReturnedCommandValidator : AbstractValidator<UpdateReturnedCommand>
{
    public UpdateReturnedCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BorrowedMaterialId).NotEmpty();
        RuleFor(c => c.PenaltyId).NotEmpty();
        RuleFor(c => c.IsPenalised).NotEmpty();
    }
}