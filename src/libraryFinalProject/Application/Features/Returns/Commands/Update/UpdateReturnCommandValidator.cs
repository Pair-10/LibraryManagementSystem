using FluentValidation;

namespace Application.Features.Returns.Commands.Update;

public class UpdateReturnCommandValidator : AbstractValidator<UpdateReturnCommand>
{
    public UpdateReturnCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BorrowedMaterialId).NotEmpty();
        RuleFor(c => c.PenaltyId).NotEmpty();
        RuleFor(c => c.IsPenalised).NotEmpty();
    }
}