using Application.Features.CategoryTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.CategoryTypes.Constants.CategoryTypesOperationClaims;

namespace Application.Features.CategoryTypes.Queries.GetList;

public class GetListCategoryTypeQuery : IRequest<GetListResponse<GetListCategoryTypeListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListCategoryTypes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetCategoryTypes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCategoryTypeQueryHandler : IRequestHandler<GetListCategoryTypeQuery, GetListResponse<GetListCategoryTypeListItemDto>>
    {
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        private readonly IMapper _mapper;

        public GetListCategoryTypeQueryHandler(ICategoryTypeRepository categoryTypeRepository, IMapper mapper)
        {
            _categoryTypeRepository = categoryTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCategoryTypeListItemDto>> Handle(GetListCategoryTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CategoryType> categoryTypes = await _categoryTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCategoryTypeListItemDto> response = _mapper.Map<GetListResponse<GetListCategoryTypeListItemDto>>(categoryTypes);
            return response;
        }
    }
}