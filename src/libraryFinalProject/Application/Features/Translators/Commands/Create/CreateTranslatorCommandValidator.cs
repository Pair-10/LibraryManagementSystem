using Application.Features.Translators.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Translators.Commands.Create;

public class CreateTranslatorCommandValidator : AbstractValidator<CreateTranslatorCommand>
{
    private ILocalizationService _localizationService;
    public CreateTranslatorCommandValidator(ILocalizationService localizationService)
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(2).MaximumLength(20);
        RuleFor(c => c.Surname).NotEmpty().MinimumLength(2).MaximumLength(30);
        RuleFor(c => c.Bio).NotEmpty().MaximumLength(1000);
        RuleFor(c => c.Website).NotEmpty().Must(BeAValidUri).WithMessage(GetLocalized("InvalidWebsiteFormat.").Result);
        _localizationService = localizationService;
    }
    private bool BeAValidUri(string website)
    {
        if (string.IsNullOrWhiteSpace(website))
            return true;
        return Uri.TryCreate(website, UriKind.Absolute, out _);
    }
    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, TranslatorsBusinessMessages.SectionName);

    }
}