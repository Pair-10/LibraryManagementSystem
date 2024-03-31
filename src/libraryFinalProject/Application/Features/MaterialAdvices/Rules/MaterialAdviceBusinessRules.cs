using Application.Features.MaterialAdvices.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Users.Constants;

namespace Application.Features.MaterialAdvices.Rules;

public class MaterialAdviceBusinessRules : BaseBusinessRules
{
    private readonly IMaterialAdviceRepository _materialAdviceRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILocalizationService _localizationService;

    public MaterialAdviceBusinessRules(IMaterialAdviceRepository materialAdviceRepository, ILocalizationService localizationService, IUserRepository userRepository)
    {
        _materialAdviceRepository = materialAdviceRepository;
        _localizationService = localizationService;
        _userRepository = userRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MaterialAdvicesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MaterialAdviceShouldExistWhenSelected(MaterialAdvice? materialAdvice)
    {
        if (materialAdvice == null)
            await throwBusinessException(MaterialAdvicesBusinessMessages.MaterialAdviceNotExists);
    }

    public async Task MaterialAdviceIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MaterialAdvice? materialAdvice = await _materialAdviceRepository.GetAsync(
            predicate: ma => ma.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaterialAdviceShouldExistWhenSelected(materialAdvice);
    }
    public async Task UserShouldBeExistsWhenSelected(User? user)
    {
        if (user == null)
            await throwBusinessException(UsersMessages.UserDontExists);
    }

    public async Task UserIdShouldBeExistsWhenSelected(Guid id)
    {
        bool doesExist = await _userRepository.AnyAsync(predicate: u => u.Id == id);
        if (doesExist)
            await throwBusinessException(UsersMessages.UserDontExists);
    }
}