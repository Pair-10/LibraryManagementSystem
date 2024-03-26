using Application.Features.UserAddresses.Constants;
using Application.Features.UserAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.UserAddresses.Constants.UserAddressesOperationClaims;

namespace Application.Features.UserAddresses.Commands.Update;

public class UpdateUserAddressCommand : IRequest<UpdatedUserAddressResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid AdressId { get; set; }

    public string[] Roles => [Admin, Write, UserAddressesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserAddresses"];

    public class UpdateUserAddressCommandHandler : IRequestHandler<UpdateUserAddressCommand, UpdatedUserAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly UserAddressBusinessRules _userAddressBusinessRules;

        public UpdateUserAddressCommandHandler(IMapper mapper, IUserAddressRepository userAddressRepository,
                                         UserAddressBusinessRules userAddressBusinessRules)
        {
            _mapper = mapper;
            _userAddressRepository = userAddressRepository;
            _userAddressBusinessRules = userAddressBusinessRules;
        }

        public async Task<UpdatedUserAddressResponse> Handle(UpdateUserAddressCommand request, CancellationToken cancellationToken)
        {
            UserAddress? userAddress = await _userAddressRepository.GetAsync(predicate: ua => ua.Id == request.Id, cancellationToken: cancellationToken);
            await _userAddressBusinessRules.UserAddressShouldExistWhenSelected(userAddress);
            userAddress = _mapper.Map(request, userAddress);

            await _userAddressRepository.UpdateAsync(userAddress!);

            UpdatedUserAddressResponse response = _mapper.Map<UpdatedUserAddressResponse>(userAddress);
            return response;
        }
    }
}