using Application.Features.UserAddresses.Constants;
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

namespace Application.Features.UserAddresses.Commands.Delete;

public class DeleteUserAddressCommand : IRequest<DeletedUserAddressResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, UserAddressesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserAddresses"];

    public class DeleteUserAddressCommandHandler : IRequestHandler<DeleteUserAddressCommand, DeletedUserAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly UserAddressBusinessRules _userAddressBusinessRules;

        public DeleteUserAddressCommandHandler(IMapper mapper, IUserAddressRepository userAddressRepository,
                                         UserAddressBusinessRules userAddressBusinessRules)
        {
            _mapper = mapper;
            _userAddressRepository = userAddressRepository;
            _userAddressBusinessRules = userAddressBusinessRules;
        }

        public async Task<DeletedUserAddressResponse> Handle(DeleteUserAddressCommand request, CancellationToken cancellationToken)
        {
            UserAddress? userAddress = await _userAddressRepository.GetAsync(predicate: ua => ua.Id == request.Id, cancellationToken: cancellationToken);
            await _userAddressBusinessRules.UserAddressShouldExistWhenSelected(userAddress);

            await _userAddressRepository.DeleteAsync(userAddress!);

            DeletedUserAddressResponse response = _mapper.Map<DeletedUserAddressResponse>(userAddress);
            return response;
        }
    }
}