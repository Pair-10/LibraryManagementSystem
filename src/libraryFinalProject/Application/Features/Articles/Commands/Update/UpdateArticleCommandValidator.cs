using FluentValidation;

namespace Application.Features.Articles.Commands.Update;

public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
{
    public UpdateArticleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.PublictionName).NotEmpty().MinimumLength(2);
    }
}