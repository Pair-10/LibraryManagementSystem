using FluentValidation;

namespace Application.Features.UserNotifications.Commands.Create;

public class CreateUserNotificationCommandValidator : AbstractValidator<CreateUserNotificationCommand>
{
    public CreateUserNotificationCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.NotificationId).NotEmpty();
    }
}