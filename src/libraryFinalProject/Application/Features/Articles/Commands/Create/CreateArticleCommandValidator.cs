using FluentValidation;

namespace Application.Features.Articles.Commands.Create;

public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValidator()
    {
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.PublictionName).NotEmpty();
    }
}