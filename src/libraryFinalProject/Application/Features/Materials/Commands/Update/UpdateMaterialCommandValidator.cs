using Application.Features.Materials.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Materials.Commands.Update;

public class UpdateMaterialCommandValidator : AbstractValidator<UpdateMaterialCommand>
{
    private ILocalizationService _localizationService;
    public UpdateMaterialCommandValidator(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PublicationDate).NotEmpty().Must(BeEarlierThanNow).WithMessage(GetLocalized("InvalidDateFormat").Result); ;
        RuleFor(c => c.Language).NotEmpty();
        RuleFor(c => c.PageCount).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.MaterialName).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
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