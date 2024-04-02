using Application.Features.Publishers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Addresses.Constants;

namespace Application.Features.Publishers.Rules;

public class PublisherBusinessRules : BaseBusinessRules
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IAddressRepository _addressRepository;
    public PublisherBusinessRules(IPublisherRepository publisherRepository, ILocalizationService localizationService, IAddressRepository addressRepository)
    {
        _publisherRepository = publisherRepository;
        _localizationService = localizationService;
        _addressRepository = addressRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PublishersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PublisherShouldExistWhenSelected(Publisher? publisher)
    {
        if (publisher == null)
            await throwBusinessException(PublishersBusinessMessages.PublisherNotExists);
    }

    public async Task PublisherIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Publisher? publisher = await _publisherRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PublisherShouldExistWhenSelected(publisher);
    }

    // iþ kuralý yayýnevi adýnýn benzersiz olup olmadýðýný kontrol eder
    public async Task PublisherNameShouldBeUnique(string name)
    {
        Publisher? existingPublisher = await _publisherRepository.GetAsync(
            predicate: p => p.Name == name,
            enableTracking: false
        );

        if (existingPublisher != null)
        {
            await throwBusinessException(PublishersBusinessMessages.PublisherNameNotUnique);
        }
    }

    public async Task AddressShouldExistWhenSelected(Address? address)
    {
        if (address == null)
            await throwBusinessException(AddressesBusinessMessages.AddressNotExists);
    }

    public async Task AddressIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Address? address = await _addressRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AddressShouldExistWhenSelected(address);
    }
}
