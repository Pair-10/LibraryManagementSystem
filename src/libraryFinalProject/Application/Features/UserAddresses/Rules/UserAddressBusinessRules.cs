using Application.Features.Addresses.Constants;
using Application.Features.UserAddresses.Constants;
using Application.Features.Users.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.UserAddresses.Rules;

public class UserAddressBusinessRules : BaseBusinessRules
{
    private readonly IUserAddressRepository _userAddressRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IUserRepository _userRepository;
    private readonly IAddressRepository _addressRepository;

    public UserAddressBusinessRules(IUserAddressRepository userAddressRepository, ILocalizationService localizationService, IUserRepository userRepository, IAddressRepository addressRepository)
    {
        _userAddressRepository = userAddressRepository;
        _localizationService = localizationService;
        _userRepository = userRepository;
        _addressRepository = addressRepository;
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

    public async Task AddressShouldExistWhenSelected(Address? address)
    {
        if (address == null)
            await throwBusinessException(AddressesBusinessMessages.AddressNotExists);
    }

    public async Task AddressIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Address? address = await _addressRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AddressShouldExistWhenSelected(address);
    }
}