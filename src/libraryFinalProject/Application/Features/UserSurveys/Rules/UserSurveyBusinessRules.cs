using Application.Features.UserSurveys.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserSurveys.Rules;

public class UserSurveyBusinessRules : BaseBusinessRules
{
    private readonly IUserSurveyRepository _userSurveyRepository;
    private readonly ILocalizationService _localizationService;

    public UserSurveyBusinessRules(IUserSurveyRepository userSurveyRepository, ILocalizationService localizationService)
    {
        _userSurveyRepository = userSurveyRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserSurveysBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserSurveyShouldExistWhenSelected(UserSurvey? userSurvey)
    {
        if (userSurvey == null)
            await throwBusinessException(UserSurveysBusinessMessages.UserSurveyNotExists);
    }

    public async Task UserSurveyIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserSurvey? userSurvey = await _userSurveyRepository.GetAsync(
            predicate: us => us.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserSurveyShouldExistWhenSelected(userSurvey);
    }
}