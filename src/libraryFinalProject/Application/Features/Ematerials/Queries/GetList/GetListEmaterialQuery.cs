using Application.Features.Ematerials.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Ematerials.Constants.EmaterialsOperationClaims;

namespace Application.Features.Ematerials.Queries.GetList;

public class GetListEmaterialQuery : IRequest<GetListResponse<GetListEmaterialListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListEmaterials({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetEmaterials";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListEmaterialQueryHandler : IRequestHandler<GetListEmaterialQuery, GetListResponse<GetListEmaterialListItemDto>>
    {
        private readonly IEmaterialRepository _ematerialRepository;
        private readonly IMapper _mapper;

        public GetListEmaterialQueryHandler(IEmaterialRepository ematerialRepository, IMapper mapper)
        {
            _ematerialRepository = ematerialRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEmaterialListItemDto>> Handle(GetListEmaterialQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Ematerial> ematerials = await _ematerialRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEmaterialListItemDto> response = _mapper.Map<GetListResponse<GetListEmaterialListItemDto>>(ematerials);
            return response;
        }
    }
}