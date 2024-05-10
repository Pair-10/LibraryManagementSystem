using Application.Features.Books.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Books.Commands.Create;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    private ILocalizationService _localizationService;
    public CreateBookCommandValidator(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.ISBN).NotEmpty().Matches(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$")
       .WithMessage(GetLocalized("InvalidISBNFormat").Result);
    }
    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, BooksBusinessMessages.SectionName);

    }
}