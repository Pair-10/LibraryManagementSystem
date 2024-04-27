using Application.Features.Surveys.Constants;
using Application.Features.Users.Constants;
using Application.Features.UserSurveys.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.UserSurveys.Rules;

public class UserSurveyBusinessRules : BaseBusinessRules
{
    private readonly IUserSurveyRepository _userSurveyRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IUserRepository _userRepository;
    private readonly ISurveyRepository _surveyRepository;

    public UserSurveyBusinessRules(IUserSurveyRepository userSurveyRepository, ILocalizationService localizationService, IUserRepository userRepository, ISurveyRepository surveyRepository)
    {
        _userSurveyRepository = userSurveyRepository;
        _localizationService = localizationService;
        _userRepository = userRepository;
        _surveyRepository = surveyRepository;
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
    public async Task UserShouldExistWhenSelected(User? user)
    {
        if (user == null)
            await throwBusinessException(UsersMessages.UserDontExists);
    }

    public async Task UserIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserShouldExistWhenSelected(user);
    }

    public async Task SurveyShouldExistWhenSelected(Survey? survey)
    {
        if (survey == null)
            await throwBusinessException(SurveysBusinessMessages.SurveyNotExists);
    }

    public async Task SurveyIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Survey? survey = await _surveyRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SurveyShouldExistWhenSelected(survey);
    }
}