using FluentValidation;

namespace Application.Features.Magazines.Commands.Create;

public class CreateMagazineCommandValidator : AbstractValidator<CreateMagazineCommand>
{
    public CreateMagazineCommandValidator()
    {
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.ISSN).NotEmpty();
        RuleFor(c => c.ISSN).NotEmpty().Length(8).Matches(@"^\d{4}-\d{4}$");
        RuleFor(c => c.Issue).NotEmpty();
    }
}