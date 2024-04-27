using FluentValidation;

namespace Application.Features.UserActivities.Commands.Update;

public class UpdateUserActivityCommandValidator : AbstractValidator<UpdateUserActivityCommand>
{
    public UpdateUserActivityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ActivityId).NotEmpty();
        RuleFor(c => c.ParticipationStatus).NotEmpty();
        RuleFor(c => c.ParticipationDate).NotEmpty();
    }
}