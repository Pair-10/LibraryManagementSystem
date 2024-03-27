using FluentValidation;

namespace Application.Features.UserActivities.Commands.Create;

public class CreateUserActivityCommandValidator : AbstractValidator<CreateUserActivityCommand>
{
    public CreateUserActivityCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ActivityId).NotEmpty();
        RuleFor(c => c.ParticipationStatus).NotEmpty();
        RuleFor(c => c.ParticipationDate).NotEmpty();
    }
}