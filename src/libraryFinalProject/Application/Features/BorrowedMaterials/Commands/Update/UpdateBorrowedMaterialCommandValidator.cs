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
        RuleFor(c => c.Deadline).Must(BeValidDeadlineDate).WithMessage(GetLocalized("InvalidDeadlineDate.").Result).NotEmpty();//ge�mi� tarih kontrol�
    }
    private bool BeValidDeadlineDate(DateTime date)
    {
        return date >= DateTime.Today;
    }
    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, BorrowedMaterialsBusinessMessages.SectionName);

    }
}