using Application.Features.Authors.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Authors.Commands.Update;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    private ILocalizationService _localizationService;
    public UpdateAuthorCommandValidator(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MinimumLength(2).MaximumLength(50)
          .WithMessage(GetLocalized("AuthorNameMustCharactersLength").Result);
        RuleFor(c => c.Surname).NotEmpty().MinimumLength(2).MaximumLength(50)
          .WithMessage(GetLocalized("AuthorSurnameMustCharactersLength").Result);
        RuleFor(c => c.Bio).NotEmpty().MaximumLength(500)
          .WithMessage(GetLocalized("BioMustCharactersLength").Result);
        RuleFor(c => c.WebSite).NotEmpty().Must(BeAValidUri)
          .WithMessage(GetLocalized("InvalidWebsiteFormat.").Result);

    }
    private bool BeAValidUri(string website)
    {
        if (string.IsNullOrWhiteSpace(website))
            return true;
        return Uri.TryCreate(website, UriKind.Absolute, out _);
    }
    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, AuthorsBusinessMessages.SectionName);

    }

}