using FluentValidation;

namespace Application.Features.Magazines.Commands.Update;

public class UpdateMagazineCommandValidator : AbstractValidator<UpdateMagazineCommand>
{
    public UpdateMagazineCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.ISSN).NotEmpty();
        RuleFor(c => c.Issue).NotEmpty();
    }
}