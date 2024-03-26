using Application.Features.MaterialTranslators.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MaterialTranslators.Constants.MaterialTranslatorsOperationClaims;

namespace Application.Features.MaterialTranslators.Queries.GetList;

public class GetListMaterialTranslatorQuery : IRequest<GetListResponse<GetListMaterialTranslatorListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMaterialTranslators({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMaterialTranslators";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMaterialTranslatorQueryHandler : IRequestHandler<GetListMaterialTranslatorQuery, GetListResponse<GetListMaterialTranslatorListItemDto>>
    {
        private readonly IMaterialTranslatorRepository _materialTranslatorRepository;
        private readonly IMapper _mapper;

        public GetListMaterialTranslatorQueryHandler(IMaterialTranslatorRepository materialTranslatorRepository, IMapper mapper)
        {
            _materialTranslatorRepository = materialTranslatorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaterialTranslatorListItemDto>> Handle(GetListMaterialTranslatorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MaterialTranslator> materialTranslators = await _materialTranslatorRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMaterialTranslatorListItemDto> response = _mapper.Map<GetListResponse<GetListMaterialTranslatorListItemDto>>(materialTranslators);
            return response;
        }
    }
}