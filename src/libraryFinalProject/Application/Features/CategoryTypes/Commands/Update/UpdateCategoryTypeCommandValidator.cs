using FluentValidation;

namespace Application.Features.CategoryTypes.Commands.Update;

public class UpdateCategoryTypeCommandValidator : AbstractValidator<UpdateCategoryTypeCommand>
{
    public UpdateCategoryTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.TypeId).NotEmpty();
    }
}