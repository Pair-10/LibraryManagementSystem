using FluentValidation;

namespace Application.Features.Surveys.Commands.Update;

public class UpdateSurveyCommandValidator : AbstractValidator<UpdateSurveyCommand>
{
    public UpdateSurveyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty().MinimumLength(2).MaximumLength(30);
        RuleFor(c => c.Description).NotEmpty().MinimumLength(2).MaximumLength(1000);
    }
}