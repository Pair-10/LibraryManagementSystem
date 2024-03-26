using FluentValidation;

namespace Application.Features.MaterialAuthors.Commands.Delete;

public class DeleteMaterialAuthorCommandValidator : AbstractValidator<DeleteMaterialAuthorCommand>
{
    public DeleteMaterialAuthorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}