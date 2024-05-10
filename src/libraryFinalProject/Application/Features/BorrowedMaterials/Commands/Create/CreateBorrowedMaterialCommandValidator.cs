using Application.Features.BorrowedMaterials.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.BorrowedMaterials.Commands.Create;

public class CreateBorrowedMaterialCommandValidator : AbstractValidator<CreateBorrowedMaterialCommand>
{
    private ILocalizationService _localizationService;
    public CreateBorrowedMaterialCommandValidator(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        //RuleFor(c => c.Deadline).Must(BeValidDeadlineDate).WithMessage(GetLocalized("InvalidDeadlineDate.").Result).NotEmpty();//geçmiþ tarih kontrolü
    }
    private bool BeValidDeadlineDate(DateTime date)//kontrol edilecek son teslim tarihi
    {
        return date >= DateTime.Today;//bugunden buyuk beya eþitse tarih true döndür
    }
    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, BorrowedMaterialsBusinessMessages.SectionName);

    }
}