using Application.Features.MaterialAdvices.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MaterialAdvices.Constants.MaterialAdvicesOperationClaims;

namespace Application.Features.MaterialAdvices.Queries.GetList;

public class GetListMaterialAdviceQuery : IRequest<GetListResponse<GetListMaterialAdviceListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMaterialAdvices({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMaterialAdvices";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMaterialAdviceQueryHandler : IRequestHandler<GetListMaterialAdviceQuery, GetListResponse<GetListMaterialAdviceListItemDto>>
    {
        private readonly IMaterialAdviceRepository _materialAdviceRepository;
        private readonly IMapper _mapper;

        public GetListMaterialAdviceQueryHandler(IMaterialAdviceRepository materialAdviceRepository, IMapper mapper)
        {
            _materialAdviceRepository = materialAdviceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaterialAdviceListItemDto>> Handle(GetListMaterialAdviceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MaterialAdvice> materialAdvices = await _materialAdviceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMaterialAdviceListItemDto> response = _mapper.Map<GetListResponse<GetListMaterialAdviceListItemDto>>(materialAdvices);
            return response;
        }
    }
}