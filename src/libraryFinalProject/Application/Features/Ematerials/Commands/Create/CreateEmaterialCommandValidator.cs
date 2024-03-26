using FluentValidation;

namespace Application.Features.Ematerials.Commands.Create;

public class CreateEmaterialCommandValidator : AbstractValidator<CreateEmaterialCommand>
{
    public CreateEmaterialCommandValidator()
    {
        RuleFor(c => c.CategoryTypeId).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.PdfUrl).NotEmpty();
    }
}