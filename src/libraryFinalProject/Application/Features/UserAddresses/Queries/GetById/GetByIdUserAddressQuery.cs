using Application.Features.UserAddresses.Constants;
using Application.Features.UserAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.UserAddresses.Constants.UserAddressesOperationClaims;

namespace Application.Features.UserAddresses.Queries.GetById;

public class GetByIdUserAddressQuery : IRequest<GetByIdUserAddressResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdUserAddressQueryHandler : IRequestHandler<GetByIdUserAddressQuery, GetByIdUserAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly UserAddressBusinessRules _userAddressBusinessRules;

        public GetByIdUserAddressQueryHandler(IMapper mapper, IUserAddressRepository userAddressRepository, UserAddressBusinessRules userAddressBusinessRules)
        {
            _mapper = mapper;
            _userAddressRepository = userAddressRepository;
            _userAddressBusinessRules = userAddressBusinessRules;
        }

        public async Task<GetByIdUserAddressResponse> Handle(GetByIdUserAddressQuery request, CancellationToken cancellationToken)
        {
            UserAddress? userAddress = await _userAddressRepository.GetAsync(predicate: ua => ua.Id == request.Id, cancellationToken: cancellationToken);
            await _userAddressBusinessRules.UserAddressShouldExistWhenSelected(userAddress);

            GetByIdUserAddressResponse response = _mapper.Map<GetByIdUserAddressResponse>(userAddress);
            return response;
        }
    }
}