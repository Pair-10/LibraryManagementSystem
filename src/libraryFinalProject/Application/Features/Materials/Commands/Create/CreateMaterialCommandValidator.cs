using Application.Features.Materials.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Materials.Commands.Create;

public class CreateMaterialCommandValidator : AbstractValidator<CreateMaterialCommand>
{
    private ILocalizationService _localizationService;
    public CreateMaterialCommandValidator(ILocalizationService localizationService)
    {
        RuleFor(c => c.PublicationDate).NotEmpty().Must(BeEarlierThanNow).WithMessage(GetLocalized("InvalidDateFormat").Result);
        RuleFor(c => c.Language).NotEmpty();
        RuleFor(c => c.PageCount).NotEmpty().LessThanOrEqualTo(500);
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.MaterialName).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(c => c.Quantity).NotEmpty().GreaterThanOrEqualTo(0).LessThanOrEqualTo(20);
        _localizationService = localizationService;
    }

    private bool BeEarlierThanNow(DateTime selectedDate)
    {
        return selectedDate < DateTime.Now;
    }
    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, MaterialsBusinessMessages.SectionName);

    }
}