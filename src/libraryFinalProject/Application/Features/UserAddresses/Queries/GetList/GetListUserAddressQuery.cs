using Application.Features.UserAddresses.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.UserAddresses.Constants.UserAddressesOperationClaims;

namespace Application.Features.UserAddresses.Queries.GetList;

public class GetListUserAddressQuery : IRequest<GetListResponse<GetListUserAddressListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListUserAddresses({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetUserAddresses";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListUserAddressQueryHandler : IRequestHandler<GetListUserAddressQuery, GetListResponse<GetListUserAddressListItemDto>>
    {
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IMapper _mapper;

        public GetListUserAddressQueryHandler(IUserAddressRepository userAddressRepository, IMapper mapper)
        {
            _userAddressRepository = userAddressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserAddressListItemDto>> Handle(GetListUserAddressQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserAddress> userAddresses = await _userAddressRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserAddressListItemDto> response = _mapper.Map<GetListResponse<GetListUserAddressListItemDto>>(userAddresses);
            return response;
        }
    }
}