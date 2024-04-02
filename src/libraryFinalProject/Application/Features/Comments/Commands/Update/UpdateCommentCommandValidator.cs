using FluentValidation;

namespace Application.Features.Comments.Commands.Update;

public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
{
    public UpdateCommentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.CommentDate).NotEmpty();
        RuleFor(c => c.CommentDesc).NotEmpty().MinimumLength(8).MaximumLength(200).WithMessage("Girilen yorum en az 8 en fazla 200 karakter uzunluðuunda olmalý ve boþ olmamalýdýr.");
    }
}