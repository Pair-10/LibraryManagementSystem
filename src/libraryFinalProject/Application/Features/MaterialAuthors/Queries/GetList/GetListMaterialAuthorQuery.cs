using Application.Features.MaterialAuthors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MaterialAuthors.Constants.MaterialAuthorsOperationClaims;

namespace Application.Features.MaterialAuthors.Queries.GetList;

public class GetListMaterialAuthorQuery : IRequest<GetListResponse<GetListMaterialAuthorListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMaterialAuthors({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMaterialAuthors";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMaterialAuthorQueryHandler : IRequestHandler<GetListMaterialAuthorQuery, GetListResponse<GetListMaterialAuthorListItemDto>>
    {
        private readonly IMaterialAuthorRepository _materialAuthorRepository;
        private readonly IMapper _mapper;

        public GetListMaterialAuthorQueryHandler(IMaterialAuthorRepository materialAuthorRepository, IMapper mapper)
        {
            _materialAuthorRepository = materialAuthorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaterialAuthorListItemDto>> Handle(GetListMaterialAuthorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MaterialAuthor> materialAuthors = await _materialAuthorRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMaterialAuthorListItemDto> response = _mapper.Map<GetListResponse<GetListMaterialAuthorListItemDto>>(materialAuthors);
            return response;
        }
    }
}