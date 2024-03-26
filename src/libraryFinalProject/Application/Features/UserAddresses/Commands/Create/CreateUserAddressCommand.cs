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

namespace Application.Features.UserAddresses.Commands.Create;

public class CreateUserAddressCommand : IRequest<CreatedUserAddressResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid UserId { get; set; }
    public Guid AdressId { get; set; }

    public string[] Roles => [Admin, Write, UserAddressesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserAddresses"];

    public class CreateUserAddressCommandHandler : IRequestHandler<CreateUserAddressCommand, CreatedUserAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly UserAddressBusinessRules _userAddressBusinessRules;

        public CreateUserAddressCommandHandler(IMapper mapper, IUserAddressRepository userAddressRepository,
                                         UserAddressBusinessRules userAddressBusinessRules)
        {
            _mapper = mapper;
            _userAddressRepository = userAddressRepository;
            _userAddressBusinessRules = userAddressBusinessRules;
        }

        public async Task<CreatedUserAddressResponse> Handle(CreateUserAddressCommand request, CancellationToken cancellationToken)
        {
            UserAddress userAddress = _mapper.Map<UserAddress>(request);

            await _userAddressRepository.AddAsync(userAddress);

            CreatedUserAddressResponse response = _mapper.Map<CreatedUserAddressResponse>(userAddress);
            return response;
        }
    }
}