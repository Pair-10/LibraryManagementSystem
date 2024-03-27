using FluentValidation;

namespace Application.Features.ActivityNotifications.Commands.Delete;

public class DeleteActivityNotificationCommandValidator : AbstractValidator<DeleteActivityNotificationCommand>
{
    public DeleteActivityNotificationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}