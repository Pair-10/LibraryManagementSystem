using FluentValidation;

namespace Application.Features.Authors.Commands.Create;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Surname).NotEmpty();
        RuleFor(c => c.Bio).MaximumLength(500).WithMessage("Bio cannot exceed 500 characters.");//Bio alanýnýn max karakter sayýsý belirt
        RuleFor(c => c.WebSite)//
                 .Must(BeAValidUri).WithMessage("Invalid Website Format.");//Geçersiz Web Sitesi formatý //

    }
    private bool BeAValidUri(string website)//
    {//
        if (string.IsNullOrWhiteSpace(website))//
            return true; // Boþ deðer kabul et//
        return Uri.TryCreate(website, UriKind.Absolute, out _);//
    }//

}