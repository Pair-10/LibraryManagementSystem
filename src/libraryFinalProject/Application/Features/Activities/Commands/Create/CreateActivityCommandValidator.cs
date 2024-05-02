using Application.Features.Activities.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Activities.Commands.Create;

public class CreateActivityCommandValidator : AbstractValidator<CreateActivityCommand>
{
    private ILocalizationService _localizationService;
    public CreateActivityCommandValidator(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
        RuleFor(c => c.ActivityDate).Must(BeValidActivityDate).WithMessage(GetLocalized("InvalidActivityDate").Result).NotEmpty();//ge�mi� tarih kontrol�
        RuleFor(c => c.Desc).MaximumLength(250).WithMessage(GetLocalized("DescCannotExceed250Characters").Result).NotEmpty();//A��klama alan� max karakter say�s� belirt
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.ActivityName).NotEmpty();
        RuleFor(c => c.Location).NotEmpty();

    }
    private bool BeValidActivityDate(DateTime date)//kontrol edilecek entkinlik tarihi
    {
        return date >= DateTime.Today;//bugunden buyuk beya e�itse tarih true d�nd�r
    }
    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, ActivitiesBusinessMessages.SectionName);

    }
}