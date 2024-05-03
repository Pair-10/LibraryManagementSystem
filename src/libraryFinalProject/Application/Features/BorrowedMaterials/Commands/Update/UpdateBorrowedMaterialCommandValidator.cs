using Application.Features.BorrowedMaterials.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.BorrowedMaterials.Commands.Update;

public class UpdateBorrowedMaterialCommandValidator : AbstractValidator<UpdateBorrowedMaterialCommand>
{
    private ILocalizationService _localizationService;
    public UpdateBorrowedMaterialCommandValidator(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Deadline).Must(BeValidDeadlineDate).WithMessage(GetLocalized("InvalidDeadlineDate.").Result).NotEmpty();//geçmiþ tarih kontrolü
    }

    private bool BeValidDeadlineDate(DateTime date)//kontrol edilecek son teslim tarihi
    {
        return date >= DateTime.Today;//bugunden buyuk beya eşitse tarih true döndür
    }



    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, BorrowedMaterialsBusinessMessages.SectionName);

    }
}