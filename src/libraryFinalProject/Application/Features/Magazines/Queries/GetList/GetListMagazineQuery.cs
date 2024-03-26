using Application.Features.Magazines.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Magazines.Constants.MagazinesOperationClaims;

namespace Application.Features.Magazines.Queries.GetList;

public class GetListMagazineQuery : IRequest<GetListResponse<GetListMagazineListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMagazines({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMagazines";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMagazineQueryHandler : IRequestHandler<GetListMagazineQuery, GetListResponse<GetListMagazineListItemDto>>
    {
        private readonly IMagazineRepository _magazineRepository;
        private readonly IMapper _mapper;

        public GetListMagazineQueryHandler(IMagazineRepository magazineRepository, IMapper mapper)
        {
            _magazineRepository = magazineRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMagazineListItemDto>> Handle(GetListMagazineQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Magazine> magazines = await _magazineRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMagazineListItemDto> response = _mapper.Map<GetListResponse<GetListMagazineListItemDto>>(magazines);
            return response;
        }
    }
}