using Application.Features.BasketEmaterials.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.BasketEmaterials.Commands.Update;

public class UpdateBasketEmaterialCommandValidator : AbstractValidator<UpdateBasketEmaterialCommand>
{
    private ILocalizationService _localizationService;
    public UpdateBasketEmaterialCommandValidator(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.EmaterialId).NotEmpty();
        RuleFor(c => c.BasketId).NotEmpty();
        RuleFor(c => c.TotalPrice).NotEmpty()
          .GreaterThan(0).WithMessage(GetLocalized("TotalPriceMustBeGreaterThan0").Result);
        RuleFor(c => c.Quantity).NotEmpty()
            .GreaterThan(0).WithMessage(GetLocalized("QuantityMustBeGreaterThan0").Result);
    }
    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, BasketEmaterialsBusinessMessages.SectionName);

    }
}