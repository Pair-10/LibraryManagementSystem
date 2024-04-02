using FluentValidation;

namespace Application.Features.Returneds.Commands.Create;

public class CreateReturnedCommandValidator : AbstractValidator<CreateReturnedCommand>
{
    public CreateReturnedCommandValidator()
    {
        RuleFor(c => c.BorrowedMaterialId).NotEmpty();
        RuleFor(c => c.IsPenalised).NotEmpty();
    }
}