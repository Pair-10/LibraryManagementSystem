using FluentValidation;

namespace Application.Features.Translators.Commands.Create;

public class CreateTranslatorCommandValidator : AbstractValidator<CreateTranslatorCommand>
{
    public CreateTranslatorCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(2).MaximumLength(20);
        RuleFor(c => c.Surname).NotEmpty().MinimumLength(2).MaximumLength(30);
        RuleFor(c => c.Bio).NotEmpty().MaximumLength(1000).WithMessage("Bio cannot exceed 1000 characters.");
        RuleFor(c => c.Website).NotEmpty().Must(BeAValidUri).WithMessage("Invalid Website Format.");//Geçersiz Web Sitesi formati;

    }
    private bool BeAValidUri(string website)//
    {//
        if (string.IsNullOrWhiteSpace(website))//
            return true; // Bos deger kabul et//
        return Uri.TryCreate(website, UriKind.Absolute, out _);//
    }//
}