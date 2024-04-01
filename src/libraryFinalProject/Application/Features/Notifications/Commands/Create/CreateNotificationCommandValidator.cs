using FluentValidation;

namespace Application.Features.Notifications.Commands.Create;

public class CreateNotificationCommandValidator : AbstractValidator<CreateNotificationCommand>
{
    public CreateNotificationCommandValidator()
    {
        RuleFor(c => c.NotificationDesc).NotEmpty().MinimumLength(7).MaximumLength(250)
       .WithMessage("Notification description must not be empty and must be at least 7 and at most 250 characters.");
        // Bildirim açýklamasý boþ olmamalý ve en az 7, en fazla 250 karakter olmalýdýr

        RuleFor(c => c.NotificationDate).NotEmpty().Must(date => date > DateTime.Today)
        .WithMessage("The notification date must be later than today.");
        //Bildirim tarihi bugünden ileri bir tarih olmalýdýr.

        RuleFor(c => c.NotificationType).NotEmpty()
        .WithMessage("Notification type should not be empty.");
        //Bildirim tipi boþ olmamalýdýr.

        RuleFor(c => c.NotificationStatus).NotEmpty();
    }

}
