using FluentValidation;

namespace Application.Features.Authors.Commands.Create;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(2).MaximumLength(50)
          .WithMessage("Name must be between 2 and 50 characters long.");//Ad degeri 2-50 karakter uzunlugunda olmali
        RuleFor(c => c.Surname).NotEmpty().MinimumLength(2).MaximumLength(50)
          .WithMessage("Surname must be between 2 and 50 characters long.");//Soyad degeri 2-50 karakter uzunlugunda olmali
        RuleFor(c => c.Bio).NotEmpty().MaximumLength(500)
          .WithMessage("Bio cannot exceed 500 characters.");//Bio alaný 500 karakteri asamaz
        RuleFor(c => c.WebSite).NotEmpty().Must(BeAValidUri)
          .WithMessage("Invalid Website Format.");//Gecersiz Web Sitesi formati

    }
    private bool BeAValidUri(string website)//web sitesi formati kontrolu
    {
        if (string.IsNullOrWhiteSpace(website))
            return true; // Bos deðer kabul et
        return Uri.TryCreate(website, UriKind.Absolute, out _);
    }

}