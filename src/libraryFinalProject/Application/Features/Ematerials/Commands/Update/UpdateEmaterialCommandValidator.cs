using FluentValidation;

namespace Application.Features.Ematerials.Commands.Update;

public class UpdateEmaterialCommandValidator : AbstractValidator<UpdateEmaterialCommand>
{
    public UpdateEmaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CategoryTypeId).NotEmpty();
        RuleFor(c => c.Price).NotEmpty().GreaterThan(0).WithMessage("Girilen fiyat bo� veya s�f�rdan k���k olamaz.");
        RuleFor(c => c.PdfUrl).NotEmpty();
    }
}