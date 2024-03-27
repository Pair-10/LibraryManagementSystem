using FluentValidation;

namespace Application.Features.Ematerials.Commands.Update;

public class UpdateEmaterialCommandValidator : AbstractValidator<UpdateEmaterialCommand>
{
    public UpdateEmaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CategoryTypeId).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.PdfUrl).NotEmpty();
    }
}