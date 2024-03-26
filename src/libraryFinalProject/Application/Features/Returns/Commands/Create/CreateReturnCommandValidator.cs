using FluentValidation;

namespace Application.Features.Returns.Commands.Create;

public class CreateReturnCommandValidator : AbstractValidator<CreateReturnCommand>
{
    public CreateReturnCommandValidator()
    {
        RuleFor(c => c.BorrowedMaterialId).NotEmpty();
        RuleFor(c => c.PenaltyId).NotEmpty();
        RuleFor(c => c.IsPenalised).NotEmpty();
    }
}