using FluentValidation;

namespace Application.Features.MaterialAdvices.Commands.Update;

public class UpdateMaterialAdviceCommandValidator : AbstractValidator<UpdateMaterialAdviceCommand>
{
    public UpdateMaterialAdviceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.AuthorName).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.MaterialName).NotEmpty();
    }
}