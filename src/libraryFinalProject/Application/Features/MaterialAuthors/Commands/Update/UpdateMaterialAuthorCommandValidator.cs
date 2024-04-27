using FluentValidation;

namespace Application.Features.MaterialAuthors.Commands.Update;

public class UpdateMaterialAuthorCommandValidator : AbstractValidator<UpdateMaterialAuthorCommand>
{
    public UpdateMaterialAuthorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
    }
}