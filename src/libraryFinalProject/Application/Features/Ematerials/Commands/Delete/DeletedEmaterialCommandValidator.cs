using FluentValidation;

namespace Application.Features.Ematerials.Commands.Delete;

public class DeleteEmaterialCommandValidator : AbstractValidator<DeleteEmaterialCommand>
{
    public DeleteEmaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}