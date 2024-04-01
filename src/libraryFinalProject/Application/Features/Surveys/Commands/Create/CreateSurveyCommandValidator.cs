using FluentValidation;

namespace Application.Features.Surveys.Commands.Create;

public class CreateSurveyCommandValidator : AbstractValidator<CreateSurveyCommand>
{
    public CreateSurveyCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty().MinimumLength(2).MaximumLength(30);
        RuleFor(c => c.Description).NotEmpty().MinimumLength(2).MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");
    }
}