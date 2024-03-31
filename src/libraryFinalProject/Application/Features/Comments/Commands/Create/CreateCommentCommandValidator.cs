using FluentValidation;

namespace Application.Features.Comments.Commands.Create;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.CommentDate).NotEmpty();
        RuleFor(c => c.CommentDesc).NotEmpty().MinimumLength(8).MaximumLength(200).WithMessage("Girilen yorum en az 8 en fazla 200 karakter uzunluðuunda olmalý ve boþ olmamalýdýr.");
    }
}