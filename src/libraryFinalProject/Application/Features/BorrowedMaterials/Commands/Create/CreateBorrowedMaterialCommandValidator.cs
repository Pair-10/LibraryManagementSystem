using FluentValidation;

namespace Application.Features.BorrowedMaterials.Commands.Create;

public class CreateBorrowedMaterialCommandValidator : AbstractValidator<CreateBorrowedMaterialCommand>
{
    public CreateBorrowedMaterialCommandValidator()
    {
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Deadline).NotEmpty();
    }
}