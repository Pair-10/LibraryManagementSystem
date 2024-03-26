using FluentValidation;

namespace Application.Features.ActivityNotifications.Commands.Update;

public class UpdateActivityNotificationCommandValidator : AbstractValidator<UpdateActivityNotificationCommand>
{
    public UpdateActivityNotificationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ActivityId).NotEmpty();
        RuleFor(c => c.NotificationId).NotEmpty();
    }
}