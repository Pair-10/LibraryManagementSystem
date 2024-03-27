using FluentValidation;

namespace Application.Features.MaterialAdvices.Commands.Delete;

public class DeleteMaterialAdviceCommandValidator : AbstractValidator<DeleteMaterialAdviceCommand>
{
    public DeleteMaterialAdviceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}