using Application.Features.UserAddresses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserAddresses.Rules;

public class UserAddressBusinessRules : BaseBusinessRules
{
    private readonly IUserAddressRepository _userAddressRepository;
    private readonly ILocalizationService _localizationService;

    public UserAddressBusinessRules(IUserAddressRepository userAddressRepository, ILocalizationService localizationService)
    {
        _userAddressRepository = userAddressRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserAddressesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserAddressShouldExistWhenSelected(UserAddress? userAddress)
    {
        if (userAddress == null)
            await throwBusinessException(UserAddressesBusinessMessages.UserAddressNotExists);
    }

    public async Task UserAddressIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserAddress? userAddress = await _userAddressRepository.GetAsync(
            predicate: ua => ua.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserAddressShouldExistWhenSelected(userAddress);
    }
}