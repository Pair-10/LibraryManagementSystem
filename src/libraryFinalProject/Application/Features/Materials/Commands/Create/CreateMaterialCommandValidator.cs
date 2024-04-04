using FluentValidation;

namespace Application.Features.Materials.Commands.Create;

public class CreateMaterialCommandValidator : AbstractValidator<CreateMaterialCommand>
{
    public CreateMaterialCommandValidator()
    {
        RuleFor(c => c.PublicationDate).NotEmpty().Must(BeEarlierThanNow);
        RuleFor(c => c.Language).NotEmpty();
        RuleFor(c => c.PageCount).NotEmpty().LessThanOrEqualTo(500);
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.MaterialName).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(c => c.Quantity).NotEmpty().GreaterThanOrEqualTo(0).LessThanOrEqualTo(20);
    }

    private bool BeEarlierThanNow(DateTime selectedDate)
    {
        return selectedDate < DateTime.Now;
    }
}