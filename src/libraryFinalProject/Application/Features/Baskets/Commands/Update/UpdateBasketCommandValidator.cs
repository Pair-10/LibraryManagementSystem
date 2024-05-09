using Application.Features.Baskets.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Baskets.Commands.Update;

public class UpdateBasketCommandValidator : AbstractValidator<UpdateBasketCommand>
{
    private ILocalizationService _localizationService;
    public UpdateBasketCommandValidator(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ItemQuantity).NotEmpty()
           .GreaterThan(0).WithMessage(GetLocalized("ItemQuantityMustBeGreaterThan0").Result);
        RuleFor(c => c.TotalPrice).NotEmpty()
         .GreaterThan(0).WithMessage(GetLocalized("TotalPriceMustBeGreaterThan0").Result);
        RuleFor(c => c.UserId).NotEmpty();
    }
    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, BasketsBusinessMessages.SectionName);

    }
}