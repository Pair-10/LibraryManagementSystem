using Application.Features.OrderEMaterials.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.OrderEMaterials.Constants.OrderEMaterialsOperationClaims;

namespace Application.Features.OrderEMaterials.Queries.GetList;

public class GetListOrderEMaterialQuery : IRequest<GetListResponse<GetListOrderEMaterialListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListOrderEMaterials({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetOrderEMaterials";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListOrderEMaterialQueryHandler : IRequestHandler<GetListOrderEMaterialQuery, GetListResponse<GetListOrderEMaterialListItemDto>>
    {
        private readonly IOrderEMaterialRepository _orderEMaterialRepository;
        private readonly IMapper _mapper;

        public GetListOrderEMaterialQueryHandler(IOrderEMaterialRepository orderEMaterialRepository, IMapper mapper)
        {
            _orderEMaterialRepository = orderEMaterialRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOrderEMaterialListItemDto>> Handle(GetListOrderEMaterialQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OrderEMaterial> orderEMaterials = await _orderEMaterialRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOrderEMaterialListItemDto> response = _mapper.Map<GetListResponse<GetListOrderEMaterialListItemDto>>(orderEMaterials);
            return response;
        }
    }
}