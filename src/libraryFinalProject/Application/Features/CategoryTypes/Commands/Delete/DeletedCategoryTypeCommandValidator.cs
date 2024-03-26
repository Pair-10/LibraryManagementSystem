using FluentValidation;

namespace Application.Features.CategoryTypes.Commands.Delete;

public class DeleteCategoryTypeCommandValidator : AbstractValidator<DeleteCategoryTypeCommand>
{
    public DeleteCategoryTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}