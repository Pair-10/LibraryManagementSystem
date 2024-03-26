using Application.Features.Returns.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Returns.Constants.ReturnsOperationClaims;

namespace Application.Features.Returns.Queries.GetList;

public class GetListReturnQuery : IRequest<GetListResponse<GetListReturnListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListReturns({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetReturns";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListReturnQueryHandler : IRequestHandler<GetListReturnQuery, GetListResponse<GetListReturnListItemDto>>
    {
        private readonly IReturnRepository _returnRepository;
        private readonly IMapper _mapper;

        public GetListReturnQueryHandler(IReturnRepository returnRepository, IMapper mapper)
        {
            _returnRepository = returnRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListReturnListItemDto>> Handle(GetListReturnQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Return> returns = await _returnRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListReturnListItemDto> response = _mapper.Map<GetListResponse<GetListReturnListItemDto>>(returns);
            return response;
        }
    }
}