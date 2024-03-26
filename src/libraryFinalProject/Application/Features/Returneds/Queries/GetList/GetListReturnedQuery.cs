using Application.Features.Returneds.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Returneds.Constants.ReturnedsOperationClaims;

namespace Application.Features.Returneds.Queries.GetList;

public class GetListReturnedQuery : IRequest<GetListResponse<GetListReturnedListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListReturneds({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetReturneds";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListReturnedQueryHandler : IRequestHandler<GetListReturnedQuery, GetListResponse<GetListReturnedListItemDto>>
    {
        private readonly IReturnedRepository _returnedRepository;
        private readonly IMapper _mapper;

        public GetListReturnedQueryHandler(IReturnedRepository returnedRepository, IMapper mapper)
        {
            _returnedRepository = returnedRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListReturnedListItemDto>> Handle(GetListReturnedQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Returned> returneds = await _returnedRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListReturnedListItemDto> response = _mapper.Map<GetListResponse<GetListReturnedListItemDto>>(returneds);
            return response;
        }
    }
}