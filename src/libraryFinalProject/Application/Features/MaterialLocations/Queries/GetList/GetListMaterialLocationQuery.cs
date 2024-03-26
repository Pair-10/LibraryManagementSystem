using Application.Features.MaterialLocations.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MaterialLocations.Constants.MaterialLocationsOperationClaims;

namespace Application.Features.MaterialLocations.Queries.GetList;

public class GetListMaterialLocationQuery : IRequest<GetListResponse<GetListMaterialLocationListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMaterialLocations({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMaterialLocations";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMaterialLocationQueryHandler : IRequestHandler<GetListMaterialLocationQuery, GetListResponse<GetListMaterialLocationListItemDto>>
    {
        private readonly IMaterialLocationRepository _materialLocationRepository;
        private readonly IMapper _mapper;

        public GetListMaterialLocationQueryHandler(IMaterialLocationRepository materialLocationRepository, IMapper mapper)
        {
            _materialLocationRepository = materialLocationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaterialLocationListItemDto>> Handle(GetListMaterialLocationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MaterialLocation> materialLocations = await _materialLocationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMaterialLocationListItemDto> response = _mapper.Map<GetListResponse<GetListMaterialLocationListItemDto>>(materialLocations);
            return response;
        }
    }
}