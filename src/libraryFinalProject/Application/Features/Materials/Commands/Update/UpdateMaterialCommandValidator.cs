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
        RuleFor(c => c.PublicationDate).NotEmpty().When(c => c.PublicationDate.HasValue); 
        RuleFor(c => c.Language).NotEmpty().When(c => !string.IsNullOrEmpty(c.Language)); 
        RuleFor(c => c.PageCount).NotEmpty().When(c => c.PageCount.HasValue); 
        RuleFor(c => c.Status).NotEmpty().When(c => c.Status.HasValue); 
        RuleFor(c => c.MaterialName).NotEmpty().When(c => !string.IsNullOrEmpty(c.MaterialName)); 
        RuleFor(c => c.Quantity).NotEmpty().When(c => c.Quantity.HasValue); 
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