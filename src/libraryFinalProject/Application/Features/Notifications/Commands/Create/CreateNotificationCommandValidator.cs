using Application.Features.Notifications.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Notifications.Commands.Create;

public class CreateNotificationCommandValidator : AbstractValidator<CreateNotificationCommand>
{
    private ILocalizationService _localizationService;
    public CreateNotificationCommandValidator(ILocalizationService localizationService)
    {
        RuleFor(c => c.NotificationDesc).NotEmpty().MinimumLength(3).MaximumLength(250)
       .WithMessage(GetLocalized("DescMustBeLength").Result);

        RuleFor(c => c.NotificationDate).NotEmpty().Must(date => date > DateTime.Today)
        .WithMessage(GetLocalized("InvalidDateFormat").Result);

        RuleFor(c => c.NotificationType).NotEmpty();

        RuleFor(c => c.NotificationStatus).NotEmpty();
        _localizationService = localizationService;
    }
    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, NotificationsBusinessMessages.SectionName);

    }

}
