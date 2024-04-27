using Application.Features.Activities.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Activities.Rules;

public class ActivityBusinessRules : BaseBusinessRules
{
    private readonly IActivityRepository _activityRepository;
    private readonly ILocalizationService _localizationService;

    public ActivityBusinessRules(IActivityRepository activityRepository, ILocalizationService localizationService)
    {
        _activityRepository = activityRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ActivitiesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ActivityShouldExistWhenSelected(Activity? activity)
    {
        if (activity == null)
            await throwBusinessException(ActivitiesBusinessMessages.ActivityNotExists);
    }

    public async Task ActivityIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Activity? activity = await _activityRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ActivityShouldExistWhenSelected(activity);
    }
    public async Task ActivityShouldNotExistsWithSameName(string activityName)//aktitive ismi kontrolü
    {   // Veritabanýndan belirtilen isimle  eþleþen bir etkinlik var mý kontrol et
        Activity? activityWithSameName = await _activityRepository.GetAsync(b => b.ActivityName == activityName);
      
        if (activityWithSameName is not null)//  bu isimde bir etkinlik var ise
            throw new BusinessException(ActivitiesBusinessMessages.ActivityAlreadyExist);//hata mesajýný tanýmla messages kýsmýnda
    }

}