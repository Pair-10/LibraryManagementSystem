using FluentValidation;

namespace Application.Features.CategoryTypes.Commands.Create;

public class CreateCategoryTypeCommandValidator : AbstractValidator<CreateCategoryTypeCommand>
{
    public CreateCategoryTypeCommandValidator()
    {
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.MaterialTypeId).NotEmpty();
    }
}