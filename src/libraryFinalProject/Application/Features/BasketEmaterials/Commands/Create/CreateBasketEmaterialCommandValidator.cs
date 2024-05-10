using Application.Features.BasketEmaterials.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.BasketEmaterials.Commands.Create;

public class CreateBasketEmaterialCommandValidator : AbstractValidator<CreateBasketEmaterialCommand>
{
    private ILocalizationService _localizationService;
    public CreateBasketEmaterialCommandValidator(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
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