using Application.Features.BasketEmaterials.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.BasketEmaterials.Constants.BasketEmaterialsOperationClaims;

namespace Application.Features.BasketEmaterials.Queries.GetList;

public class GetListBasketEmaterialQuery : IRequest<GetListResponse<GetListBasketEmaterialListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBasketEmaterials({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBasketEmaterials";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBasketEmaterialQueryHandler : IRequestHandler<GetListBasketEmaterialQuery, GetListResponse<GetListBasketEmaterialListItemDto>>
    {
        private readonly IBasketEmaterialRepository _basketEmaterialRepository;
        private readonly IMapper _mapper;

        public GetListBasketEmaterialQueryHandler(IBasketEmaterialRepository basketEmaterialRepository, IMapper mapper)
        {
            _basketEmaterialRepository = basketEmaterialRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBasketEmaterialListItemDto>> Handle(GetListBasketEmaterialQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BasketEmaterial> basketEmaterials = await _basketEmaterialRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBasketEmaterialListItemDto> response = _mapper.Map<GetListResponse<GetListBasketEmaterialListItemDto>>(basketEmaterials);
            return response;
        }
    }
}