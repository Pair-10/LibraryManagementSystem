using Application.Features.Articles.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Articles.Constants.ArticlesOperationClaims;

namespace Application.Features.Articles.Queries.GetList;

public class GetListArticleQuery : IRequest<GetListResponse<GetListArticleListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListArticles({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetArticles";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListArticleQueryHandler : IRequestHandler<GetListArticleQuery, GetListResponse<GetListArticleListItemDto>>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public GetListArticleQueryHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListArticleListItemDto>> Handle(GetListArticleQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Article> articles = await _articleRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListArticleListItemDto> response = _mapper.Map<GetListResponse<GetListArticleListItemDto>>(articles);
            return response;
        }
    }
}