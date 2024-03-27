using Application.Features.MaterialPublishers.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MaterialPublishers.Constants.MaterialPublishersOperationClaims;

namespace Application.Features.MaterialPublishers.Queries.GetList;

public class GetListMaterialPublisherQuery : IRequest<GetListResponse<GetListMaterialPublisherListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMaterialPublishers({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMaterialPublishers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMaterialPublisherQueryHandler : IRequestHandler<GetListMaterialPublisherQuery, GetListResponse<GetListMaterialPublisherListItemDto>>
    {
        private readonly IMaterialPublisherRepository _materialPublisherRepository;
        private readonly IMapper _mapper;

        public GetListMaterialPublisherQueryHandler(IMaterialPublisherRepository materialPublisherRepository, IMapper mapper)
        {
            _materialPublisherRepository = materialPublisherRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaterialPublisherListItemDto>> Handle(GetListMaterialPublisherQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MaterialPublisher> materialPublishers = await _materialPublisherRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMaterialPublisherListItemDto> response = _mapper.Map<GetListResponse<GetListMaterialPublisherListItemDto>>(materialPublishers);
            return response;
        }
    }
}