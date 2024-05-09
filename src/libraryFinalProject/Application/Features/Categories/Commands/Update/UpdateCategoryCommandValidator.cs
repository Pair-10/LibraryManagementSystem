using Application.Features.Categories.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    private ILocalizationService _localizationService;
    public UpdateCategoryCommandValidator(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MinimumLength(3).MaximumLength(25).WithMessage(GetLocalized("CategoryNameMustBeLength").Result);
        RuleFor(c => c.Description).NotEmpty().MinimumLength(8).MaximumLength(100).WithMessage(GetLocalized("DescMustBeLength").Result);
        _localizationService = localizationService;
    }
    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, CategoriesBusinessMessages.SectionName);

    }
}