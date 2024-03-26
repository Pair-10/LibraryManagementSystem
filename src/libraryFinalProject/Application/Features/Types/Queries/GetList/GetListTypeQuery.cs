using Application.Features.Types.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Types.Constants.TypesOperationClaims;

namespace Application.Features.Types.Queries.GetList;

public class GetListTypeQuery : IRequest<GetListResponse<GetListTypeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListTypes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetTypes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListTypeQueryHandler : IRequestHandler<GetListTypeQuery, GetListResponse<GetListTypeListItemDto>>
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;

        public GetListTypeQueryHandler(ITypeRepository typeRepository, IMapper mapper)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTypeListItemDto>> Handle(GetListTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Type> types = await _typeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTypeListItemDto> response = _mapper.Map<GetListResponse<GetListTypeListItemDto>>(types);
            return response;
        }
    }
}