using FluentValidation;

namespace Application.Features.ActivityNotifications.Commands.Create;

public class CreateActivityNotificationCommandValidator : AbstractValidator<CreateActivityNotificationCommand>
{
    public CreateActivityNotificationCommandValidator()
    {
        RuleFor(c => c.ActivityId).NotEmpty();
        RuleFor(c => c.NotificationId).NotEmpty();
    }
}