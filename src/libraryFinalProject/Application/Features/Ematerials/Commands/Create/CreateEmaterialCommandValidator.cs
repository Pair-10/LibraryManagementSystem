using FluentValidation;

namespace Application.Features.Ematerials.Commands.Create;

public class CreateEmaterialCommandValidator : AbstractValidator<CreateEmaterialCommand>
{
    public CreateEmaterialCommandValidator()
    {
        RuleFor(c => c.CategoryTypeId).NotEmpty();
        RuleFor(c => c.Price).NotEmpty().GreaterThan(0).WithMessage("Girilen fiyat bo� veya s�f�rdan k���k olamaz.");
        RuleFor(c => c.PdfUrl).NotEmpty();
    }
}