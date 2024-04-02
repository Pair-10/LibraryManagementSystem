using FluentValidation;

namespace Application.Features.UserNotifications.Commands.Update;

public class UpdateUserNotificationCommandValidator : AbstractValidator<UpdateUserNotificationCommand>
{
    public UpdateUserNotificationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.NotificationId).NotEmpty();
    }
}