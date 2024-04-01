using FluentValidation;

namespace Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MinimumLength(5).MaximumLength(25).WithMessage("Kategori ismi en az 5 en fazla 25 karakter olabilir ve boþ olmamalý.");
        RuleFor(c => c.Description).NotEmpty().MinimumLength(8).MaximumLength(100).WithMessage("Kategori açýklamasý en az 8 en fazla 100 karakter olabilir ve boþ olmamalý.");
    }
}