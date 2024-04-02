using FluentValidation;

namespace Application.Features.UserNotifications.Commands.Delete;

public class DeleteUserNotificationCommandValidator : AbstractValidator<DeleteUserNotificationCommand>
{
    public DeleteUserNotificationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}