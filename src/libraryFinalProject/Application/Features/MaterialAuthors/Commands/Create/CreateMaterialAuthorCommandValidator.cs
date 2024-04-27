using FluentValidation;

namespace Application.Features.MaterialAuthors.Commands.Create;

public class CreateMaterialAuthorCommandValidator : AbstractValidator<CreateMaterialAuthorCommand>
{
    public CreateMaterialAuthorCommandValidator()
    {
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
    }
}